using UnityEngine;
using UnityEngine.UI;
public class EnemyWeaponsSet:MonoBehaviour
{

    public Image[] images;
    public void WeaponSet(WeaponData[] weapons)
    {
        for(int i=0; i< 5; i++)
        {
            images[i].sprite = weapons[i].weaponImage;
        }
    }
}