using UnityEngine;
using System;

public class DamageSession
{
    Enemy _enemy;
    Player _player;
    public DamageSession(Enemy enemy, Player player)
    {
        _enemy = enemy;
        _player = player;
    }
    public bool PlayerAttack(WeaponData weapon)
    {
        var damage = _player.ATK + weapon.power;
        Debug.Log("Player Attack" + damage);
        var deathFlag = _enemy.Damaged(damage);
        return deathFlag;
    }
    public bool EnemyAttack(WeaponData weapon)
    {
        var damage = _enemy.ATK+weapon.power;
        Debug.Log("Enemy Attack" + damage);
        var deathFlag =_player.Damaged(damage);
        return deathFlag;
    }
}