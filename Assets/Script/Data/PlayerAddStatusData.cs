using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAddStatusData:MonoBehaviour
{
    public int addHp;
    public int addAtk;
    public int addDfs;
    public TextMeshProUGUI addHpText;
    public TextMeshProUGUI addAtkText;
    public TextMeshProUGUI addDfsText;

    public (int, int, int) Get()
    {
        return (addHp, addAtk, addDfs);
    }
    public void Set(int hp, int atk ,int dfs)
    {
        addHp = hp;
        addAtk = atk;
        addDfs = dfs;
    }
    public void ViewSet()
    {
        addHpText.text = $"+ {addHp}";
        addAtkText.text = $"+ {addAtk}";
        addDfsText.text = $"+ {addDfs}";
    }




}