// Assets/Script/Status/EffectContext.cs
using UnityEngine;

public class EffectContext
{
    public IUnit self;                    // 効果を受ける本人
         // 任意のログ出力（なくてもOK）

    // ← これが今回の1メソッド
    public void DealSelfPercentDamage(float rate)
    {
        int dmg = Mathf.Max(1, Mathf.FloorToInt(self.HP * rate)); // 現HP×rate（最低1）
        self.Damaged(dmg);
        Debug.Log("Poison" + dmg+"damage");
        
    }
}
