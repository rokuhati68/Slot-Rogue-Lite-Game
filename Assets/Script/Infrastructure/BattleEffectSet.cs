using UnityEngine;
using UnityEngine.UI;
public class BattleEffectSet:MonoBehaviour
{

    public Image[] images;
    public void EffectSet(StatusSpec[] effects)
    {
        for(int i=0; i< 5; i++)
        {
            images[i].sprite = effects[i].icon;
        }


    }
}