// StatusPresenter.cs
using System.Collections.Generic;

public class EffectPresenter
{
    private readonly StatusController controller;
    private readonly EffectView view;

    public EffectPresenter(StatusController controller, EffectView view)
    {
        this.controller = controller;
        this.view = view;
        controller.OnChanged += OnStatusChanged;
    }

    void OnStatusChanged(IReadOnlyList<StatusController.Active> list)
    {
        var data = new List<StatusViewData>(list.Count);
        foreach (var a in list)
        {
            data.Add(new StatusViewData {
                Icon = a.spec.icon,
                Turns = a.turns,
                Name  = string.IsNullOrEmpty(a.spec.displayNameOverride)
                        ? a.spec.effect.displayName   // effect側の名前を流用
                        : a.spec.displayNameOverride,
                Rank = a.spec.rank,
                Description = a.spec.description
            });
        }
        view.View(data);
    }
}
