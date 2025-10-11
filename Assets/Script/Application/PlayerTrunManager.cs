using UnityEngine;
using System.Collections;
public class PlayerTurnManager
{
    DamageSession _damageSession;
    BattleLog _battleLog;
    WeaponSlot _weaponSlot;
    EffectSlot _effectSlot;
    StatusController _playerStatus;
    StatusController _enemyStatus;
    public PlayerTurnManager(DamageSession damageSession, BattleLog battleLog, WeaponSlot weaponSlot,
                            EffectSlot effectSlot,StatusController playerStatus, StatusController enemyStatus)
    {
        _damageSession = damageSession;
        _battleLog = battleLog;
        _weaponSlot = weaponSlot;
        _effectSlot = effectSlot;
        _playerStatus = playerStatus;
        _enemyStatus = enemyStatus;
    }
    public IEnumerator AttackFlow(Reel weaponReel, Reel effectReel, System.Action<bool> onFinished)
    {
        _battleLog.Append("PlayerTurnStart");

        // ★ Rollして結果を受け取る
        var result = _weaponSlot.Roll(); // (weapon, isHit, index)
        var effectResult = _effectSlot.Roll();
        weaponReel.SpinToIndex(result.index);
        effectReel.SpinToIndex(effectResult.index);
        while (effectReel.isSpining) yield return null;
        bool enemyDied = false;
        if (result.isHit)
        {
            _battleLog.Append($"Hit:{result.index} {result.weapon.power}");
            enemyDied = _damageSession.PlayerAttack(result.weapon);
            _enemyStatus.Apply(effectResult.effect);
        }
        else
        {    
            _battleLog.Append("Miss");        
        }
        
        onFinished(enemyDied);
        
    }



}