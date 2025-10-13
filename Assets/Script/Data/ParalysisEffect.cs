// Assets/Script/Domain/Effects/ParalysisEffect.cs
using UnityEngine;

[CreateAssetMenu(menuName = "Status/Paralysis")]
public class ParalysisEffect : StatModifierEffect
{
    
    private int disableChance = 25;  // 25%

    public override void OnTurnStart(StatusController controller)
    {
        int value = Random.Range(0,100);
        // ランダムで25%の確率で行動を無効化
        if (value < disableChance)
        {
            controller.canActThisTurn = false;
            Debug.Log( "paralyzed and cannot act!");
        }
    }
}
