// Assets/Script/Domain/Effects/ParalysisEffect.cs
using UnityEngine;

[CreateAssetMenu(menuName = "Status/Paralysis")]
public class ParalysisEffect : StatusEffect
{
    [SerializeField, Range(0f,1f)]
    private float disableChance = 0.25f;  // 25%

    public override void OnTurnStart(StatusController controller)
    {
        // ランダムで25%の確率で行動を無効化
        if (Random.value < disableChance)
        {
            controller.canActThisTurn = false;
            Debug.Log( "paralyzed and cannot act!");
        }
    }
}
