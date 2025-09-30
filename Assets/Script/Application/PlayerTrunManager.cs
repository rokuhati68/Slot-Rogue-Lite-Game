using UnityEngine;
using System.Collections;
public class PlayerTurnManager
{
    DamageSession _damageSession;
    BattleLog _battleLog;
    WeaponSlot _weaponSlot;
    public PlayerTurnManager(DamageSession damageSession, BattleLog battleLog, WeaponSlot weaponSlot)
    {
        _damageSession = damageSession;
        _battleLog = battleLog;
        _weaponSlot = weaponSlot;
    }
    public IEnumerator AttackFlow(Reel reel, System.Action<bool> onFinished)
    {
        _battleLog.Append("PlayerTurnStart");

        // ★ Rollして結果を受け取る
        var result = _weaponSlot.Roll(); // (weapon, isHit, index)

        yield return reel.SpinToIndex(result.index);

        bool enemyDied = false;
        if (result.isHit)
        {
            _battleLog.Append($"Hit:{result.index} {result.weapon.power}");
            enemyDied = _damageSession.PlayerAttack(result.weapon);
        }
        else
        {    
            _battleLog.Append("Miss");        
        }
        
        onFinished(enemyDied);
        
    }



}