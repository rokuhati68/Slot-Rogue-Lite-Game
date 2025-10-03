// Assets/Script/Domain/Effects/StatModifierEffect.cs
using UnityEngine;

public enum StatType { Attack, Defense }

// 属性は必要なものに合わせて

[CreateAssetMenu(menuName = "Status/Stat Modifier")]
public class StatModifierEffect : StatusEffect
{
    [Header("基本設定")]
    public StatType targetStat = StatType.Attack;
    public ElementType element = ElementType.None;

    [Tooltip("例えば1.2なら+20%, 0.8なら-20%")]
    public float multiplier = 1.2f;
}
