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

        // ★ Rollして結果を受け取る
        var result = _weaponSlot.Roll(); // (weapon, isHit, index)
        var effectResult = _effectSlot.Roll();
        var spec = effectResult.effect;
        Debug.Log(result.index);
        weaponReel.SpinToIndex(result.index);
        effectReel.SpinToIndex(effectResult.index);
        while(effectReel.isSpining) yield return null;
        yield return new WaitForSeconds(1f);
        bool playerDied = false;
        if (result.isHit)
        {
            
            playerDied = _damageSession.EnemyAttack(result.weapon,_enemyStatus, _playerStatus);
            var target = _enemyStatus;
            string targetName="";
            if (spec.effect is StatModifierEffect mod)
            {
                // 暗黙ルール：AttackはSelf、DefenseはEnemy
                if (mod.targetStat == StatType.Attack) 
                    {
                        target = _enemyStatus; 
                        targetName = "敵";
                    }
                else
                    {
                        target = _playerStatus;
                        targetName = "プレイヤー";
                    }
            }
            target.Apply(spec);
            _battleLog.Append(targetName +"の" + spec.appendDescription);
        }
        else
        {    
            _battleLog.Append("敵の攻撃！"); 
            _battleLog.Append("しかし、攻撃は外れた！");        
        }
        
        onFinished(playerDied);
        
    }



}