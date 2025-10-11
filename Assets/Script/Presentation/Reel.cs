using UnityEngine;
using System.Collections;

public class Reel : MonoBehaviour
{
    [SerializeField] int iconHeight;
    [SerializeField] int iconCnt;
    [SerializeField] float topPos;
    [SerializeField] float bottomPos;
    [SerializeField] float speed = 0.15f;
    [SerializeField] int maxLoopCnt; 
    public bool isSpining;
    RectTransform content;

    void Awake()
    {
        content = GetComponent<RectTransform>();
        topPos = content.anchoredPosition.y;
        bottomPos = topPos - iconHeight * iconCnt;
        
    }

    public void SpinToIndex(int targetIndex)
    {
        isSpining = true;
        StartCoroutine(SpinSlot(targetIndex));
    }
    public IEnumerator SpinSlot(int stopId)
    {
        int loopCnt = 0;

        // ぐるぐる回す（5コマぶん * iconCnt 回 = 5周のイメージ）
        while (loopCnt < maxLoopCnt)
        {
            var p = content.anchoredPosition;
            p.y -= iconHeight;
            if (p.y <= bottomPos) 
            {
                p.y = topPos;
                loopCnt += 1;
            }
            content.anchoredPosition = p;

            yield return new WaitForSeconds(speed);
        }

        // 最後に3コマだけ追加で進めて止める例
        for (int i = 0; i < stopId; i++)
        {
            var p = content.anchoredPosition;
            p.y -= iconHeight;
            if (p.y <= bottomPos) p.y = topPos;
            content.anchoredPosition = p;

            yield return new WaitForSeconds(speed);
        }
        Debug.Log("Spinend");
        isSpining = false;
    }
}
