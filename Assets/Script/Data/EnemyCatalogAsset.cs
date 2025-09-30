// EnemyCatalogAsset.cs
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/EnemyCatalog")]
public class EnemyCatalogAsset : ScriptableObject {
    public EnemyData[] Enemies;

    private Dictionary<int, EnemyData> _map;
    void OnEnable() { BuildMap(); }
    public void BuildMap() {
        _map = new Dictionary<int, EnemyData>();
        foreach (var e in Enemies)  _map[e.ID] = e;
    }
    public EnemyData TryGet(int id) =>
        _map[id];
}
