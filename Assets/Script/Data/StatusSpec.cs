// Assets/Script/Status/StatusSpec.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum StatusRank { Common, Uncommon, Rare, Epic, Legendary }

[CreateAssetMenu(menuName = "Status/Status Spec")]
public class StatusSpec : ScriptableObject
{
    [Header("見た目/メタ")]
    public string displayNameOverride;     // 表示名を上書きしたい時だけ
    public Sprite icon;                    // アイコン（毒A/毒Bで差し替え）
    [Range(0f,1f)] public float procChance = 1f; // 発動確率
    public StatusRank rank = StatusRank.Common;  // レア度

    [Header("挙動の参照（必須）")]
    public StatusEffect effect; // ← 実際のロジック（毒/麻痺など）

    [Header("持続ターン（効果ごとに変えたい時用）")]
    public int baseTurns = 3;             // 初回付与
    public int extendTurns = 3;           // 再付与(+○ターン)

    [TextArea(1, 6)]
    public string description;

    
}
