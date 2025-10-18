using UnityEngine;
using System.Collections.Generic;
public class AddStatusSet:MonoBehaviour
{
    [SerializeField] PlayerAddStatusData[] nowAddStatus;
    [SerializeField] PlayerAddStatusData[] rewardAddStatus;
    public Player _player;

    public void RewardSet(List<(int,int,int)> add)
    {
        for(int i = 0; i < add.Count; i++)
        {
            var (addHp,addAtk,addDfs) = add[i];
            rewardAddStatus[i].Set(addHp,addAtk,addDfs);
        }
    }

    public void RewardGet(int preID, int newID)
    {
        var (addHp, addAtk, addDfs) = rewardAddStatus[newID].Get();
        nowAddStatus[preID].Set(addHp,addAtk,addDfs);
        _player.Add(addHp, addAtk, addDfs);
    }
}