// Assets/Script/Status/StatusEffect.cs
using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public string displayName;

    // まずは終了時だけ（毒はここを使う）
    public virtual void OnTurnEnd(EffectContext ctx) { }
}
