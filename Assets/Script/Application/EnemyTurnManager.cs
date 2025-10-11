using UnityEngine;
using System.Collections;
public class EnemyTurnManager
{
    DamageSession _damageSession;
    BattleLog _battleLog;
    WeaponSlot _weaponSlot;
    EffectSlot _effectSlot;
    StatusController _playerStatus;
    StatusController _enemyStatus;
    public StatusSpec poisonEffectAsset;
    public StatusSpec paralysisEffectAsset;
    public EnemyTurnManager(DamageSession damageSession, BattleLog battleLog, WeaponSlot weaponSlot
                ,EffectSlot effectSlot,StatusController playerStatus, StatusController enemyStatus)
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
        _battleLog.Append("EnemyTurnStart");

        // ★ Rollして結果を受け取る
        var result = _weaponSlot.Roll(); // (weapon, isHit, index)
        var effectResult = _effectSlot.Roll();
        Debug.Log("reelstart");
        weaponReel.SpinToIndex(result.index);
        effectReel.SpinToIndex(effectResult.index);
        while(effectReel.isSpining) yield return null;
        bool playerDied = false;
        if (result.isHit)
        {
            _battleLog.Append($"Hit:{result.index} {result.weapon.power}");
            playerDied = _damageSession.EnemyAttack(result.weapon);
            _battleLog.Append("{effectResult.index}");
            _playerStatus.Apply(effectResult.effect);
            
        }
        else
        {    
            _battleLog.Append("Miss");        
        }
        
        onFinished(playerDied);
        
    }



}