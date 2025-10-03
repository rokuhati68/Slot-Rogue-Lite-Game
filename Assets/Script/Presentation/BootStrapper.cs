using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    public BattleStartCheck _battleStartCheck;
    public Player _player;
    public Enemy _enemy;
    public EnemyCatalogAsset _enemyCatalog;
    public BattleLogPresenter _battleLogPresenter;
    public BattleManager _battleManager;
    public WeaponSlot _playerWeaponSlot;
    public WeaponSlot _enemyWeaponSlot;
    public EnemyWeaponsSet _enemyWeaponsSet;
    public EffectView enemyEffectView;
    public EffectView playerEffectView;

    // 追加（Inspectorでセット or Resources等で取得）
    public StatusSpec poisonEffect; // 例：まずは毒だけ流し込みたい時
    public StatusSpec paralysisEffect;
    void Awake()
    {
        // 1) 共通サービス
        var battleLog = new BattleLog(10);
        var damageSession = new DamageSession(_enemy, _player);

        // 2) スロット系（← プレイヤー/敵で別インスタンスにする）
        var playerSlotMgr = new SlotManager();
        var enemySlotMgr  = new SlotManager();
        _playerWeaponSlot.Init(playerSlotMgr);
        _enemyWeaponSlot.Init(enemySlotMgr);

        // 3) 敵の初期セット
        var enemyUseCase  = new EnemyUseCase(_enemy, _enemyCatalog, _enemyWeaponsSet);
        var battleSession = new BattleSession(_player, enemyUseCase, battleLog);

        // 4) 状態コントローラ（各ユニットに1つ）
        //    ※ IUnit を Player / Enemy が実装していることが前提
        var playerStatus = new StatusController(_player);
        var enemyStatus  = new StatusController(_enemy);

        // 5) ターンマネージャ
        var enemyTurnManager  = new EnemyTurnManager(damageSession, battleLog, _enemyWeaponSlot, playerStatus, enemyStatus);
        var playerTurnManager = new PlayerTurnManager(damageSession, battleLog, _playerWeaponSlot);

        // （必要なら）マネージャに Status を注入できるようプロパティを用意しておくと便利
        // enemyTurnManager.PlayerStatus = playerStatus;
        // playerTurnManager.PlayerStatus = playerStatus;
        // playerTurnManager.EnemyStatus  = enemyStatus;
        enemyTurnManager.poisonEffectAsset = poisonEffect; // 例：武器ヒット時に付与したい時
        enemyTurnManager.paralysisEffectAsset = paralysisEffect;
        // 6) Presenter / UI
        _battleLogPresenter.Init(battleLog);
        _battleStartCheck.Init(_battleManager);
        var enemyEffectPresenter = new EffectPresenter(enemyStatus,enemyEffectView);
        var playerEffectPresenter = new EffectPresenter(playerStatus, playerEffectView);
        // 7) BattleManager 初期化（必要なら Status も注入）
        _battleManager.Init(battleSession, playerTurnManager, enemyTurnManager, playerStatus, enemyStatus);
        //_battleManager.Init(battleSession, playerTurnManager, enemyTurnManager);
    }
}
