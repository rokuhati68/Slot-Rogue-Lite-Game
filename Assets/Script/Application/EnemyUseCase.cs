using UnityEngine;
using System;
public class EnemyUseCase:MonoBehaviour
{
    
    Enemy _enemy;
    EnemyCatalogAsset _enemyCatalog;
    EnemyWeaponsSet _enemyWeaponsSet;
    BattleEffectSet _battleEffectSet;
    public EnemyUseCase(Enemy enemy, EnemyCatalogAsset enemyCatalog, EnemyWeaponsSet enemyWeaponsSet,
                        BattleEffectSet battleEffectSet)
    {
        _enemy = enemy;
        _enemyCatalog = enemyCatalog;
        _enemyWeaponsSet = enemyWeaponsSet;
        _battleEffectSet = battleEffectSet;
    }

    
    public void EnemySet()
    {
        var enemy = _enemyCatalog.TryGet(1);
        _enemy.Set(enemy);
        _enemyWeaponsSet.WeaponSet(enemy.weapons);
        _battleEffectSet.EffectSet(enemy.effects);
    }
};