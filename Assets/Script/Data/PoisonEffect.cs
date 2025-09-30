// Assets/Script/Status/PoisonEffect.cs
using UnityEngine;

[CreateAssetMenu(menuName = "Status/Poison")]
public class PoisonEffect : StatusEffect
{
    [Range(0f, 1f)] public float hpRate = 0.20f;  // 現在HPの20%
    
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(displayName)) displayName = "Poison";
    }

    // 毒の振る舞い：ターン終了時に現在HP割合ダメージ
    public override void OnTurnEnd(EffectContext ctx)
    {
        Debug.Log("poisondamage");
        ctx.DealSelfPercentDamage(hpRate);
    }
}
