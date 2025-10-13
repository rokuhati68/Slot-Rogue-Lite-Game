using UnityEngine;

public class CalculateDamage
{
    int baseAtk;
    int baseDfs;
    int weaponPwr;
    float atkEff;
    float dfsEff;
    float atkMult;
    float dfsMult;
    ElementType weaponElement;
    ElementType defElement;

    float dfsFactor = 50f;
    public int Calculate(IUnit attaker, IUnit deffenser, WeaponData weapon, StatusController _atkStatus,StatusController _dfsStatus)
    {
        baseAtk = attaker.ATK;
        baseDfs = deffenser.DFS;
        weaponPwr = weapon.power; 
        weaponElement = weapon.element;
        defElement = deffenser.Element;
        atkMult = 1.0f;
        if(weaponElement == defElement && weaponElement != ElementType.None)
        {
            atkMult *= 1.5f;
        }
        atkMult *= GetAttackMultiplier(_atkStatus,weaponElement);
        dfsMult *= GetDefenseMultiplier(_dfsStatus,weaponElement);

        atkEff = baseAtk * atkMult;
        dfsEff = baseDfs * dfsMult;

        float defenseComponent = 1f + (dfsEff / Mathf.Max(1f, dfsFactor));
        float raw = atkEff / defenseComponent;

        float rnd = Random.Range(0.8f,1.2f);
        int damage = Mathf.Max(1,Mathf.FloorToInt(raw* rnd));
        return damage;
    }
    public float GetAttackMultiplier(StatusController atkStatus,ElementType weaponElement)
    {
        float total = 1f;
        foreach (var a in atkStatus._list)
        {
            if (a.spec.effect is StatModifierEffect mod)
            {
                // 攻撃系のバフ/デバフを対象に
                if (mod.targetStat == StatType.Attack)
                {
                    // 属性が指定されていなければ常時適用
                    if (mod.element == ElementType.None || mod.element == weaponElement)
                        total *= mod.multiplier;
                }
            }
        }
        return total;
    }

    public float GetDefenseMultiplier(StatusController dfsStatus,ElementType weaponElement)
    {
        float total = 1f;
        foreach (var a in dfsStatus._list)
        {
            if (a.spec.effect is StatModifierEffect mod)
            {
                // 防御系のバフ/デバフを対象に
                if (mod.targetStat == StatType.Defense)
                {
                    if (mod.element == ElementType.None || mod.element == weaponElement)
                        total *= mod.multiplier;
                }
            }
        }
        return total;
    }

}