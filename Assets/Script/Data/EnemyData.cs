using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "EnemyDeta", menuName = "Scriptable Objects/EnemyDeta")]

public class EnemyData : ScriptableObject
{
    
    public int ID;
    public string Name;
    public int rank;
    public string element;
    public int HP;
    public int ATK;
    public int DFS;
    public int SPD;
    public Sprite enemyImage;

    public WeaponData[] weapons;
    public int GetHP()
    {
        return HP;
    }

}
