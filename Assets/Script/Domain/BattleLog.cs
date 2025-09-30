// Assets/Scripts/Domain/BattleLog.cs
using System;
using System.Collections.Generic;

public class BattleLog
{
    public event Action<IReadOnlyList<string>> OnChanged;

    private readonly int capacity;
    private readonly LinkedList<string> lines = new LinkedList<string>();

    public BattleLog(int capacity = 10)
    {
        this.capacity = Math.Max(1, capacity);
    }

    public void Append(string message)
    {
        if (string.IsNullOrEmpty(message)) return;

        lines.AddLast(message);
        while (lines.Count > capacity)
            lines.RemoveFirst();

        OnChanged?.Invoke(GetLines());
    }

    public void Clear()
    {
        if (lines.Count == 0) return;
        lines.Clear();
        OnChanged?.Invoke(GetLines());
    }

    public IReadOnlyList<string> GetLines()
    {
        var list = new List<string>(lines.Count);
        foreach (var s in lines) list.Add(s);
        return list;
    }
}
