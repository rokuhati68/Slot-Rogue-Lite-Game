using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class LogView:MonoBehaviour
{
    public TextMeshProUGUI logText;
    [SerializeField] ScrollRect scrollRect;
    bool _autoFollowBottom = true;
    public void BattleLogView(IReadOnlyList<string> lines)
    {   
        
        logText.text = string.Join("\n", lines);
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)logText.transform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.content);

        if (_autoFollowBottom)
        {
            // 1=最上、0=最下
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }

    
    

}