using UnityEngine;

public class BattleSession
{
    PlayerUseCase _playerUseCase;
    EnemyUseCase _enemyUseCase;
    BattleLog _battleLog;
    public BattleSession(PlayerUseCase playerUseCase, EnemyUseCase enemyUseCase, BattleLog log)
    {
        _playerUseCase = playerUseCase;
        _enemyUseCase = enemyUseCase;
        _battleLog = log;
    }
    public void BattleSet()
    {
        _playerUseCase.PlayerSet();
        _enemyUseCase.EnemySet();
        _battleLog.Append("Battle Start!");
    }

}