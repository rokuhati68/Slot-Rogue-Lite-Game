using UnityEngine;
using System.Collections.Generic;
public class RewardSelector
{
    WeaponCatalogAsset catalog;
    public RewardRandomizer rewardRandomizer;
    public int choicesCount = 3;
    public RewardSelector(WeaponCatalogAsset _catalog)
    {
        rewardRandomizer = new RewardRandomizer(_catalog);
        catalog =_catalog;
    }
    public WeaponData[] Select(EnemyRank rank)
    {
        var ids = new List<int>(choicesCount);
        for (int i = 0; i < choicesCount; i++)
        {
            var id = rewardRandomizer.Choose(rank);
            if (id < 0) break;
            ids.Add(id);
            
        }

        // ID → WeaponData に変換してUIへ
        var arr = new WeaponData[ids.Count];
        Debug.Log(arr.Length);
        for (int i = 0; i < ids.Count; i++)
            {Debug.Log(ids[i]);
            arr[i] = catalog.Weapons[ids[i]];}
        return arr;
    }
}