using UnityEngine;
using System;
public class EnemyUseCase:MonoBehaviour
{
    
    Enemy _enemy;
    EnemyCatalogAsset _enemyCatalog;
    WeaponsUISet _enemyWeaponsSet;
    BattleEffectSet _battleEffectSet;
    WeaponSlot _enemyWeaponSlot;
    EffectSlot _enemyEffectSlot;
    public EnemyUseCase(Enemy enemy, EnemyCatalogAsset enemyCatalog, WeaponsUISet enemyWeaponsSet,
                        BattleEffectSet battleEffectSet,WeaponSlot enemyWeaponSlot,EffectSlot enemyEffectSlot)
    {
        _enemy = enemy;
        _enemyCatalog = enemyCatalog;
        _enemyWeaponsSet = enemyWeaponsSet;
        _battleEffectSet = battleEffectSet;
        _enemyWeaponSlot = enemyWeaponSlot;
        _enemyEffectSlot = enemyEffectSlot;
    }


    public void EnemySet()
    {
        var enemy = _enemyCatalog.TryGet(1);
        _enemy.Set(enemy);
        _enemyWeaponsSet.WeaponSet(enemy.weapons);
        _battleEffectSet.EffectSet(enemy.effects);
        _enemyWeaponSlot.WeaponSet(enemy.weapons);
        _enemyEffectSlot.EffectSet(enemy.effects);
    }
};