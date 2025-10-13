using UnityEngine;
using System;

public class DamageSession
{
    Enemy _enemy;
    Player _player;
    CalculateDamage _calculateDamage;
    public DamageSession(Enemy enemy, Player player, CalculateDamage calculateDamage)
    {
        _enemy = enemy;
        _player = player;
        _calculateDamage = calculateDamage;
    }
    public bool PlayerAttack(WeaponData weapon,StatusController _enemyStatus, StatusController _playerStatus)
    {
        var damage = _calculateDamage.Calculate(_player,_enemy, weapon,_playerStatus,_enemyStatus);
        Debug.Log("Player Attack" + damage);
        var deathFlag = _enemy.Damaged(damage);
        return deathFlag;
    }
    public bool EnemyAttack(WeaponData weapon, StatusController _enemyStatus, StatusController _playerStatus)
    {
        var damage = _calculateDamage.Calculate(_enemy, _player,weapon, _enemyStatus, _playerStatus);
        Debug.Log("Enemy Attack" + damage);
        var deathFlag =_player.Damaged(damage);
        return deathFlag;
    }
}