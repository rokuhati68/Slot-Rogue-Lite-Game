using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum Turn {Set, PlayerAttack, EnemyAttack,PlayerDeath, EnemyDeath}
public class BattleManager:MonoBehaviour
{
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
    public void Init(BattleSession battleSession, PlayerTurnManager playerTurnManager, EnemyTurnManager enemyTurnManager
                    ,StatusController playerStatus, StatusController enemyStatus)
    {
        _battleSession = battleSession;
        _playerTurnManager = playerTurnManager;
        _enemyTurnManager = enemyTurnManager;
        _playerStatus = playerStatus;
        _enemyStatus = enemyStatus;
        turn = Turn.Set;
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
                    Debug.Log("PlayerTurnStart");
                    _playerStatus.OnTurnStart();
                    if (_playerStatus.canActThisTurn)
                    {
                        yield return StartCoroutine(_playerTurnManager.AttackFlow(
                        playerReel,
                        delegate (bool died){enemyDied = died;}
                        ));
                    }
                    
                    _playerStatus.OnTurnEnd();
                    turn = enemyDied ? Turn.EnemyDeath : Turn.EnemyAttack;
                    yield return new WaitForSeconds(0.5f); 
                    break;
                }
                case Turn.EnemyAttack:
                {
                    Debug.Log("EnemyTurnStart");
                    _enemyStatus.OnTurnStart();
                    if (_enemyStatus.canActThisTurn)
                    {
                        yield return StartCoroutine(_enemyTurnManager.AttackFlow(
                            enemyReel,
                            delegate (bool died){playerDied = died;}
                        ));
                    }
                    _enemyStatus.OnTurnEnd();
                    turn = playerDied ? Turn.PlayerDeath : Turn.PlayerAttack;
                    yield return new WaitForSeconds(0.5f); 
                    break;
                }
                case Turn.PlayerDeath:
                yield break;
                case Turn.EnemyDeath:
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