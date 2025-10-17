using UnityEngine;
using UnityEngine.UI;
public class WeaponsUISet:MonoBehaviour
{

    public Image[] images;
    public void WeaponSet(WeaponData[] weapons, int cnt)
    {
        for(int i=0; i< cnt; i++)
        {
            images[i].sprite = weapons[i].weaponImage;
        }
    }
}