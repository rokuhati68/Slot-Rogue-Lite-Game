using UnityEngine;
using System.Collections.Generic;
public class AddStatusRandomizer
{
    Dictionary<EnemyRank,int> minAdd = new Dictionary<EnemyRank,int>();
    Dictionary<EnemyRank,int> maxAdd = new Dictionary<EnemyRank,int>();

    public AddStatusRandomizer()
    {
        foreach(EnemyRank rank in  System.Enum.GetValues(typeof(EnemyRank)))
        {
            switch (rank)
            {
                case EnemyRank.Low:
                    minAdd.Add(rank,0);
                    maxAdd.Add(rank,5);
                    break;
                case EnemyRank.Mid:
                    minAdd.Add(rank,3);
                    maxAdd.Add(rank,8);
                    break;
                case EnemyRank.High:
                    minAdd.Add(rank,5);
                    maxAdd.Add(rank,10);
                    break;
                case EnemyRank.Boss:
                    minAdd.Add(rank,5);
                    maxAdd.Add(rank,15);
                    break;
            }
        }
    }
    public (int,int,int) Decide(EnemyRank rank)
    {
        var addHp = Random.Range(minAdd[rank],maxAdd[rank] + 1);
        var addAtk = Random.Range(minAdd[rank],maxAdd[rank]+ 1);
        var addDfs = Random.Range(minAdd[rank],maxAdd[rank] +1);
        return (addHp,addAtk,addDfs);
    }



}