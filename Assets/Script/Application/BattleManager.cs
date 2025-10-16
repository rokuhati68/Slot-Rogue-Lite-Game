using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum Turn {Set, PlayerAttack, EnemyAttack,PlayerDeath, EnemyDeath}
public class BattleManager:MonoBehaviour
{
    public event System.Action<int> OnBattleFinished;
    BattleSession _battleSession;
    PlayerTurnManager _playerTurnManager;
    EnemyTurnManager _enemyTurnManager;
    Turn turn;
    bool enemyDied;
    bool playerDied;
    public Reel playerReel;
    public Reel enemyReel;
    StatusController _playerStatus;
    StatusController _enemyStatus;
    public GameObject playerReels;
    public GameObject enemyReels;
    Reel playerWeaponReel;
    Reel playerEffectReel;
    Reel enemyWeaponReel;
    Reel enemyEffectReel;
    BattleLog _battleLog;
    public void Init(BattleSession battleSession, PlayerTurnManager playerTurnManager, EnemyTurnManager enemyTurnManager
                    ,StatusController playerStatus, StatusController enemyStatus,BattleLog battleLog)
    {
        _battleSession = battleSession;
        _playerTurnManager = playerTurnManager;
        _enemyTurnManager = enemyTurnManager;
        _playerStatus = playerStatus;
        _enemyStatus = enemyStatus;
        _battleLog = battleLog;
        turn = Turn.Set;
        Reel[] _playerReelList = playerReels.GetComponentsInChildren<Reel>(true);
        playerWeaponReel = _playerReelList[0];
        playerEffectReel = _playerReelList[1];
        Reel[] _enemyReelList = enemyReels.GetComponentsInChildren<Reel>(true);
        enemyWeaponReel = _enemyReelList[0];
        enemyEffectReel = _enemyReelList[1];
        
    }
    
    public void BattleStart()
    { 
        turn = Turn.Set;
        StartCoroutine(BattleLoop());
    }

    IEnumerator BattleLoop()
    {
        if(turn == Turn.Set)
        {
            BattleSet();
        }
        while(true)
        {
            switch(turn)
            {
                case Turn.PlayerAttack:
                {
                    _battleLog.Append("～ プレイヤーターン ～");
                    enemyReels.SetActive(false);
                    playerReels.SetActive(true);
                    _playerStatus.OnTurnStart();
                    if (_playerStatus.canActThisTurn)
                    {
                        yield return StartCoroutine(_playerTurnManager.AttackFlow(
                        playerWeaponReel,playerEffectReel,
                        delegate (bool died){enemyDied = died;}
                        ));
                    }
                    else _battleLog.Append("しかし、動けなかった!");
                    _playerStatus.OnTurnEnd();
                    turn = enemyDied ? Turn.EnemyDeath : Turn.EnemyAttack;
                    yield return new WaitForSeconds(0.5f); 
                    break;
                }
                case Turn.EnemyAttack:
                {
                    playerReels.SetActive(false);
                    enemyReels.SetActive(true);
                    _battleLog.Append("～ 敵ターン ～");
                    _enemyStatus.OnTurnStart();
                    if (_enemyStatus.canActThisTurn)
                    {
                        yield return StartCoroutine(_enemyTurnManager.AttackFlow(
                            enemyWeaponReel,enemyEffectReel,
                            delegate (bool died){playerDied = died;}
                        ));
                    }
                    else _battleLog.Append("しかし、動けなかった!");
                    _enemyStatus.OnTurnEnd();
                    turn = playerDied ? Turn.PlayerDeath : Turn.PlayerAttack;
                    yield return new WaitForSeconds(0.5f); 
                    break;
                }
                case Turn.PlayerDeath:
                OnBattleFinished?.Invoke(0);
                yield break;
                case Turn.EnemyDeath:
                OnBattleFinished?.Invoke(1);
                yield break;
            }
        }
    }
    public void BattleSet()
    {
        enemyDied = false;
        playerDied = false;
        _battleSession.BattleSet();
        turn = Turn.PlayerAttack;
    }
    
}