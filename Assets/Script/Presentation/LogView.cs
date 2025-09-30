using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class LogView:MonoBehaviour
{
    public TextMeshProUGUI logText;

    public void BattleLogView(IReadOnlyList<string> lines)
    {   
        
        logText.text = string.Join("\n", lines);
    }

}