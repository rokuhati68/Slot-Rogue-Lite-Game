using UnityEngine;

public class BattleSession
{
    Player _player;
    EnemyUseCase _enemyUseCase;
    BattleLog _battleLog;
    public BattleSession(Player player, EnemyUseCase enemyUseCase, BattleLog log)
    {
        _player = player;
        _enemyUseCase = enemyUseCase;
        _battleLog = log;
    }
    public void BattleSet()
    {
        _player.Set(200, 20, 50);
        _enemyUseCase.EnemySet();
        _battleLog.Append("Battle Start!");
    }

}