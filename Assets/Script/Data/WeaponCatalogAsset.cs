// EnemyCatalogAsset.cs
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game/WeaponCatalog")]
public class WeaponCatalogAsset : ScriptableObject {
    public WeaponData[] Weapons;

    private Dictionary<int, WeaponData> _map;
    void OnEnable() { BuildMap(); }
    public void BuildMap() {
        _map = new Dictionary<int, WeaponData>();
        foreach (var w in Weapons)  _map[w.ID] = w;
    }
    public WeaponData TryGet(int id) =>
        _map[id];
}
