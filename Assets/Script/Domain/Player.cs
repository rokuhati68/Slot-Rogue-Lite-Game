using UnityEngine;
using System;

public class Player : MonoBehaviour, IUnit
{
    public event Action PlayerSet;
    public event Action PlayerDamaged;
    [SerializeField] int maxHp;
    [SerializeField] int hp;   // ← Inspectorで表示される
    [SerializeField] int atk;
    [SerializeField] int dfs;

    public int MaxHP { get => maxHp; set => maxHp = value; }
    public int HP { get => hp; set => hp = value; }  // ← 外部から操作可能
    public int ATK { get => atk; set => atk = value; }
    public int DFS { get => dfs; set => dfs = value; }

    int IUnit.ATK => atk;
    int IUnit.DFS => dfs;

    public StatusController Status { get; private set; }
    public ElementType Element => ElementType.None;

    void Awake()
    {
        Status = new StatusController(this);
    }

    public void Set(int Hp, int Atk, int Dfs)
    {
        maxHp= Hp;
        hp = Hp;
        atk = Atk;
        dfs = Dfs;
        Debug.Log("HP" + hp);
        PlayerSet?.Invoke();
    }
    public void Reset()
    {
        hp = maxHp;
        PlayerSet?.Invoke();
    }
    public bool Damaged(int damage)
    {
        var deathFlag = false;
        hp -= damage;
        PlayerDamaged?.Invoke();
        if (hp <= 0)
        {
            deathFlag = true;
        }
        Debug.Log("playerHP " + hp);
        return deathFlag;
    }

    public void Add(int addHp, int addAtk, int addDfs)
    {
        maxHp += addHp;
        atk += addAtk;
        dfs += addDfs;
        Debug.Log("AddStatus");
        PlayerSet?.Invoke();
    }
}
