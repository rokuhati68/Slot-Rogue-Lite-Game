using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectView : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject iconPrefab;

    public void View(List<StatusViewData> data)
    {
        // 1) 既存の子を全部破棄（SetActiveではなくDestroy）
        ClearChildren();

        // 2) 最新データで再生成
        for (int i = 0; i < data.Count; i++)
        {
            var go = Instantiate(iconPrefab, content ? content : transform);

            // 画像
            var img = go.GetComponentInChildren<Image>(true);
            if (img) img.sprite = data[i].Icon;

            // 残りターン
            var turns = go.GetComponentInChildren<TextMeshProUGUI>(true);
            if (turns) turns.text = $"remind turn {data[i].Turns}";

            // 説明（Prefab内のパスに合わせて）
            var descTr = go.transform.Find("BackGraund/Explain");
            if (descTr)
            {
                var desc = descTr.GetComponent<TextMeshProUGUI>();
                if (desc) desc.text = data[i].Description;
            }
        }
    }

    void ClearChildren()
    {
        var parent = content ? content : transform;
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
    }
}
