using UnityEngine;
using System.Collections.Generic;
public class AddStatusSelector
{
    
    public AddStatusRandomizer addStatusRandomizer;
    public int choicesCount = 3;
    public AddStatusSelector()
    {
        addStatusRandomizer = new AddStatusRandomizer();
    }
    public List<(int,int,int)> Select(EnemyRank rank)
    {
        var adds = new List<(int,int,int)>();
        for (int i = 0; i < choicesCount; i++)
        {
            var (addHp,addAtk,addDfs) = addStatusRandomizer.Decide(rank);
            adds.Add((addHp,addAtk,addDfs));
            
        }

        return adds;
    }
}