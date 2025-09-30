using UnityEngine;
using System;
public class Player:MonoBehaviour,IUnit
{
    public event Action PlayerSet;
    public event Action PlayerDamaged;
    public int MaxHP=> HP;
    public int HP{ get; set; }
    public int ATK;
    public int DFS;
    public StatusController Status { get; private set; }
    public ElementType Element => ElementType.None;

    void Awake()
    {
        Status = new StatusController(this);
    }
    public void Set(int Hp, int Atk, int Dfs)
    {
        HP = Hp;
        ATK = Atk;
        DFS = Dfs;
        PlayerSet?.Invoke();
    }
    public bool Damaged(int damage)
    {
        var deathFlag = false;
        HP -= damage;
        PlayerDamaged?.Invoke();
        if (HP <= 0)
        {deathFlag = true;}
        Debug.Log("playerHP"+HP);
        return deathFlag;
    }
}