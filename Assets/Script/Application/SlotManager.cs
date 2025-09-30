using UnityEngine;


public class SlotManager
{
    int preId = 0;

    public int DecideSlot()
    {
        int nxtId = Random.Range(0,5);
        preId = nxtId;
        return nxtId;
    }

}
