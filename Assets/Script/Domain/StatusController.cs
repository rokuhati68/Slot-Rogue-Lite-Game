// Assets/Script/Status/StatusController.cs（要点差分）
using System;
using System.Collections.Generic;
using UnityEngine;

public class StatusController
{
    public class Active
    {
        public StatusSpec spec;   // ★ ここを StatusEffect ではなく Spec に
        public int turns;
        public Active(StatusSpec s, int t){ spec=s; turns=t; }
    }

    private readonly IUnit _self;
    private readonly List<Active> _list = new List<Active>();
    public event Action<IReadOnlyList<Active>> OnChanged; // UI通知（Presenterが購読）

    public StatusController(IUnit self){ _self = self; }

    private EffectContext Ctx() => new EffectContext{ self = _self };

    // ★ Spec を受け取る（同じ Spec はターン延長）
    public void Apply(StatusSpec spec)
    {
        var a = _list.Find(x => x.spec == spec);
        if (a == null) { a = new Active(spec, Mathf.Max(1, spec.baseTurns)); _list.Add(a); }
        else { a.turns += Mathf.Max(1, spec.extendTurns); }
        OnChanged?.Invoke(_list);
    }

    public void OnTurnEnd()
    {
        var ctx = Ctx();

        // ロジック実行は Spec.effect に委譲（例：毒の OnTurnEnd でHP減） 
        for (int i=0;i<_list.Count;i++)
            _list[i].spec.effect.OnTurnEnd(ctx);

        // 寿命進行
        
        for (int i=_list.Count-1;i>=0;i--)
        {
            _list[i].turns--;
            Debug.Log("減った");
            if (_list[i].turns<=0){ _list.RemoveAt(i);}
        }
        OnChanged?.Invoke(_list);
    }

    public IEnumerable<Active> Items => _list;
}
