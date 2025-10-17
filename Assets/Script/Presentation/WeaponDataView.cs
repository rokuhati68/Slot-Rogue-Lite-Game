using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponDataView : MonoBehaviour
{
    public void View(WeaponData[] data, int cnt)
    {
        // 1) 既存の子を全部破棄（SetActiveではなくDestroy）
        HorizontalLayoutGroup[] allChildrens = GetComponentsInChildren<HorizontalLayoutGroup>();
        // 2) 最新データで再生成
        for(int i = 0; i< cnt; i ++)
        {
            var children = allChildrens[i].transform.Find("weapon").gameObject;
            var Texts = children.transform.Find("Text").gameObject;
            var nameText = Texts.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            var elementText = Texts.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            var powerText = Texts.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            var accuracyText = Texts.transform.GetChild(3).GetComponent<TextMeshProUGUI>();

            nameText.text = data[i].Name;
            elementText.text = $"属性 : {data[i].element}";
            powerText.text = $"威力 : {data[i].power}";
            accuracyText.text = $"命中率 : {data[i].accuracy}";
        }
    }
}
