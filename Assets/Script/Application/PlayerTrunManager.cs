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

        // ★ Rollして結果を受け取る
        var result = _weaponSlot.Roll(); // (weapon, isHit, index)
        var effectResult = _effectSlot.Roll();
        var spec = effectResult.effect;
        weaponReel.SpinToIndex(result.index);
        effectReel.SpinToIndex(effectResult.index);
        while (effectReel.isSpining) yield return null;
        yield return new WaitForSeconds(1f);
        bool enemyDied = false;
        if (result.isHit)
        {
            enemyDied = _damageSession.PlayerAttack(result.weapon,_enemyStatus,_playerStatus);
            var target = _enemyStatus;
            if (spec.effect is StatModifierEffect mod)
            {
                // 暗黙ルール：AttackはSelf、DefenseはEnemy
                if (mod.targetStat == StatType.Attack) target = _playerStatus;
                else                                    target = _enemyStatus;
            }
            target.Apply(spec);
        }
        else
        {    
            _battleLog.Append("プレイヤーの攻撃！");
            _battleLog.Append("しかし、攻撃は外れた！");        
        }
        
        onFinished(enemyDied);
        
    }



}