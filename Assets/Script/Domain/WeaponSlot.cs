using UnityEngine;
using System.Collections.Generic;
public class WeaponSlot:MonoBehaviour
{
    public List<WeaponData> WeaponsList = new List<WeaponData>();
    public SlotManager _slotManager;
    public int preId = 0;
    public void Init(SlotManager slotManager)
    {_slotManager = slotManager;}
    public void WeaponSet(WeaponData[] weapons)
    {
        for(int i = 0; i < 5; i++)
        {
            Set(i, weapons[i]);
        }
    }
    public void Set(int id, WeaponData newWeapon)
    {
        WeaponsList[id] = newWeapon;
    }
    public WeaponData Get(int? id = null)
    {
        int index = id ?? preId;
        return WeaponsList[index];
    }

    
    public (WeaponData weapon, bool isHit, int index) Roll()
    {
        preId = _slotManager.DecideSlot();
        var weapon = Get(preId);
        bool hit = weapon.HitCheck();
        return (weapon, hit, preId);
    }
}