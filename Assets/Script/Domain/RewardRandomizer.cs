using UnityEngine;
using System.Collections.Generic;
public class RankRewardData
{
    public List<float> _weights = new List<float>();
    public float _totalWeight;
    public List<int> weaponIDs= new List<int>();
    public void Add(int id, int weight)
    {
        _weights.Add(weight);
        _totalWeight += weight;
        weaponIDs.Add(id);
    }
}
public class RewardRandomizer
{
    Dictionary<EnemyRank,RankRewardData> _rewardDict = new Dictionary<EnemyRank,RankRewardData>();

    public  RewardRandomizer(WeaponCatalogAsset catalog)
    {
        var weapons = catalog.Weapons;
        _rewardDict[EnemyRank.Low]  = new RankRewardData();
        _rewardDict[EnemyRank.Mid]  = new RankRewardData();
        _rewardDict[EnemyRank.High] = new RankRewardData();
        _rewardDict[EnemyRank.Boss] = new RankRewardData();
        MakeTable(weapons);
        
    }
    void MakeTable(WeaponData[] weapons)
    {
        
        for(int i = 0; i < weapons.Length; i++)
        {
            var weapon = weapons[i];
            var rank = weapon.rank;
            var id = weapon.ID;
            switch(rank)
            {
                case WeaponRank.Worst:
                    AddLowTable(i,7);
                    AddMidTable(i,4);
                    break;
                case WeaponRank.Low:
                    AddLowTable(i,3);
                    AddMidTable(i,8);
                    break;
                case WeaponRank.Mid:
                    AddLowTable(i,1);
                    AddMidTable(i,15);
                    AddHighTable(i,10);
                    break;
                case WeaponRank.High:
                    AddMidTable(i,2);
                    AddHighTable(i,8);
                    AddBossTable(i,5);
                    break;
                case WeaponRank.Legend:
                    AddHighTable(i,4);
                    AddBossTable(i,6);
                    break;
            }
                    
        }
    }
    public int Choose(EnemyRank rank)
    {
        var table = _rewardDict[EnemyRank.Low];
        var _weights = table._weights;
        var _totalWeight = table._totalWeight;
        var weaponIDs = table.weaponIDs;
        Debug.Log("cnt" + _weights.Count);
        // 0～重みの総和の範囲の乱数値取得
        var randomPoint = UnityEngine.Random.Range(0, _totalWeight);

        // 乱数値が属する要素を先頭から順に選択
        var currentWeight = 0f;
        for (var i = 0; i < _weights.Count; i++)
        {
            // 現在要素までの重みの総和を求める
            currentWeight += _weights[i];

            // 乱数値が現在要素の範囲内かチェック
            if (randomPoint < currentWeight)
            {
                return weaponIDs[i];
            }
        }

        // 乱数値が重みの総和以上なら末尾要素とする
        return weaponIDs[_weights.Count - 1];
    }
    void AddLowTable(int id, int weight)
    {
        var table = _rewardDict[EnemyRank.Low];
        table.Add(id,weight);
    }
    void AddMidTable(int id, int weight)
    {
        var table = _rewardDict[EnemyRank.Mid];
        table.Add(id,weight);
    }
    void AddHighTable(int id, int weight)
    {
        var table = _rewardDict[EnemyRank.High];
        table.Add(id,weight);
    }
    void AddBossTable(int id, int weight)
    {
        var table = _rewardDict[EnemyRank.Boss];
        table.Add(id,weight);
    }
}