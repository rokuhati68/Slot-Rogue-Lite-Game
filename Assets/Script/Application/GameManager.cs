using UnityEngine;
using System.Collections;
public enum GameState
{
    StageSelect,   // 次に戦うステージを選ぶ（or 自動で次へ）
    Battle,        // 戦闘
    Reward,        // 戦闘後の武器選択
    GameOver,      // 全滅など
}

public class GameManager : MonoBehaviour
{
    public BattleManager _battleManager;   // 既存参照
    public RewardManager _rewardManager;   // 既存参照

    public GameState State { get; private set; } = GameState.StageSelect;

    // ステージ管理（必要ならSOや配列で）
    //[SerializeField] private StageData[] _stages;
    private int _stageIndex = 0;

    private void Start()
    {
        // イベント購読
        _battleManager.OnBattleFinished += HandleBattleFinished;
        //_rewardManager.OnRewardSelected += HandleRewardSelected;

        // 入口
        EnterStageSelect();
    }

    private void OnDestroy()
    {
        _battleManager.OnBattleFinished -= HandleBattleFinished;
        //_rewardManager.OnRewardSelected -= HandleRewardSelected;
    }

    // ====== 状態遷移 ======

    private void EnterStageSelect()
    {
        State = GameState.StageSelect;

        // 1) 自動で次ステージに進むタイプ
        //if (_stageIndex >= _stages.Length) { EnterGameOver(true); return; }
        //StartCoroutine(StageFlowRoutine(_stages[_stageIndex]));
        
        // 2) もしUIで選ばせるなら：
        // ShowStageSelectPanel(_stages, onSelected: idx => {
        //     _stageIndex = idx;
        //     StartCoroutine(StageFlowRoutine(_stages[_stageIndex]));
        // });
    }

    private IEnumerator StageFlowRoutine()
    {
        // Battle
        State = GameState.Battle;
        _battleManager.BattleStart(); // 内部で演出→勝敗判定→OnBattleFinished

        // OnBattleFinished で次に進むので、ここでは待たない。
        yield break;
    }

    private void HandleBattleFinished(int result)
    {
        if (result==0)
        {
            Debug.Log("GameOver");
            return;
        }

        // 勝利時はリワードへ
        EnterReward();
    }

    private void EnterReward()
    {
        State = GameState.Reward;

        // 抽選（内部でWeaponRandomizerに委譲するか、ここで渡す）
        // 例：Battle側で作る
        // あるいは GameManager 側で： var rewardChoices = _rewardManager.Generate(stage, runData);

        _rewardManager.ShowPanel(); // パネル表示＆選択待ち（OnRewardSelectedを待つ）
    }

    private void HandleRewardSelected(WeaponData selected)
    {
        // 受け取り：インベントリ更新など
        // PlayerInventory.AddWeapon(selected);

        // 次のステージへ進行
        _stageIndex++;
        EnterStageSelect();
    }

    private void EnterGameOver(bool clearedAll)
    {
        State = GameState.GameOver;
        // クリアか敗北かで分岐して表示
        // ShowGameOverPanel(clearedAll);
        // リトライ押下で： ResetRun(); _stageIndex = 0; EnterStageSelect();
    }
}