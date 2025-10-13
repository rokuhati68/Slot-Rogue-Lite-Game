using UnityEngine;
using System;

public class DamageSession
{
    Enemy _enemy;
    Player _player;
    CalculateDamage _calculateDamage;
    BattleLog _battleLog;
    public DamageSession(Enemy enemy, Player player, CalculateDamage calculateDamage,BattleLog battleLog)
    {
        _enemy = enemy;
        _player = player;
        _calculateDamage = calculateDamage;
        _battleLog = battleLog;
    }
    public bool PlayerAttack(WeaponData weapon,StatusController _enemyStatus, StatusController _playerStatus)
    {
        var damage = _calculateDamage.Calculate(_player,_enemy, weapon,_playerStatus,_enemyStatus);
        _battleLog.Append("プレイヤーの攻撃！");
        _battleLog.Append(damage + "ダメージを与えた！");
        var deathFlag = _enemy.Damaged(damage);
        return deathFlag;
    }
    public bool EnemyAttack(WeaponData weapon, StatusController _enemyStatus, StatusController _playerStatus)
    {
        var damage = _calculateDamage.Calculate(_enemy, _player,weapon, _enemyStatus, _playerStatus);
        _battleLog.Append("敵の攻撃！");
        _battleLog.Append(damage + "ダメージを与えた！");
        var deathFlag =_player.Damaged(damage);
        return deathFlag;
    }
}