using UnityEngine;
using System.Collections.Generic;
public class EffectSlot:MonoBehaviour
{
    public List<StatusSpec> EffectList = new List<StatusSpec>();
    public SlotManager _slotManager;
    public int preId = 0;
    public void Init(SlotManager slotManager)
    {_slotManager = slotManager;}

    public void EffectSet(StatusSpec[] spec)
    {
        for(int i = 0; i < 5; i++)
        {
            Set(i, spec[i]);
        }
    }
    public void Set(int id, StatusSpec spec)
    {
        EffectList[id] = spec;
    }
    public StatusSpec Get(int? id = null)
    {
        int index = id ?? preId;
        return EffectList[index];
    }

    
    public (StatusSpec effect, int index) Roll()
    {
        preId = _slotManager.DecideSlot();
        var effect = Get(preId);
        return (effect, preId);
    }
}