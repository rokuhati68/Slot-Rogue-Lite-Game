using UnityEngine;
using System;
public class Enemy:MonoBehaviour,IUnit
{
    public event Action EnemySet;
    public event Action EnemyDamaged;
    public int ID;
    public int MaxHP=> HP;
    public int HP{ get; set; }
    public int ATK;
    public int DFS;
    public string Name;
    public Sprite Image;
    public StatusController Status { get; private set; }
    public ElementType Element => ElementType.None;

    void Awake()
    {
        Status = new StatusController(this);
    }
    public void Set(EnemyData enemy)
    {
        ID = enemy.ID;
        HP = enemy.HP;
        ATK = enemy.ATK;
        DFS = enemy.DFS;
        Name = enemy.Name;
        Image = enemy.enemyImage;
        EnemySet?.Invoke();
    }
    public bool Damaged(int damage)
    {
        var deathFlag = false;
        HP -= damage;
        EnemyDamaged?.Invoke();
        if (HP <= 0)
        {deathFlag = true;}
        return deathFlag;
    }
}