using UnityEngine;
using UnityEngine.UI;

public class BattleStartCheck:MonoBehaviour
{
    public Button battleStartButton;
    BattleManager _battleManager;
    public void Init(BattleManager battleManager)
    {
        _battleManager = battleManager;
        battleStartButton.onClick.AddListener(() => _battleManager.BattleStart());
    }

}