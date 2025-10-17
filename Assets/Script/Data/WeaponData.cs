using UnityEngine;
using UnityEngine.UI;
public enum WeaponRank{Worst,Low,Mid,High,Legend}
[CreateAssetMenu(fileName = "WeaponDeta", menuName = "Scriptable Objects/WeaponDeta")]

public class WeaponData : ScriptableObject
{
    
    public int ID;
    public string Name;
    public WeaponRank rank;
    public ElementType element = ElementType.None;
    public int power;
    public int accuracy;
    public Sprite weaponImage;
    int price;

    public int GetPower()
    {
        return power;
    }
    public bool HitCheck()
    {
        var value = Random.Range(0,100);
        if (value <= accuracy) return true;
        else return false;
    }
}
