using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class BattleLogPresenter:MonoBehaviour
{
    public LogView _view;
    BattleLog _battleLog;
    public void Init(BattleLog battleLog)
    {
        _battleLog = battleLog;
    }
    void Start()
    {
        _battleLog.OnChanged +=LogView;
    }

    void OnDisable()
    {
        _battleLog.OnChanged -= LogView;
    }

    void LogView(IReadOnlyList<string> log)
    {
        _view.BattleLogView(log);
    }


    
}