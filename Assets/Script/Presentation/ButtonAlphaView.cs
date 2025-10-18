using UnityEngine;

public class AlphaSetter : MonoBehaviour
{
    [Header("透明度を変更する対象（CanvasGroupを持つオブジェクト）")]
    public CanvasGroup[] nowtargets;  // ← Inspectorで登録しておく
    public CanvasGroup[] rewardtargets;
    [ContextMenu("Set All Alpha to 1")] // 右クリックメニューからも実行可
    public void SetANowAlphaToOne()
    {
        foreach (var t in nowtargets)
        {
            if (t == null) continue;
            t.alpha = 1f;
            t.interactable = true;
            t.blocksRaycasts = true;
        }
    }
    public void SetARewardAlphaToOne()
    {
        foreach (var t in rewardtargets)
        {
            if (t == null) continue;
            t.alpha = 1f;
            t.interactable = true;
            t.blocksRaycasts = true;
        }
    }
}
