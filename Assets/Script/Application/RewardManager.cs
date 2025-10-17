using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class RewardManager:MonoBehaviour
{
    [SerializeField] WeaponCatalogAsset catalog;
    public RewardSelector rewardSelector;
    public GameObject rewardPanel;
    public WeaponsUISet nowWeaponsUISet;
    public WeaponsUISet rewardWeaponsUISet;
    public BattleEffectSet nowEffectSet;
    public BattleEffectSet rewardEffectSet;
    public PlayerData _playerData;
    public TextMeshProUGUI[] status;
    public WeaponDataView weaponDataView;
    public WeaponDataView rewardWeaponData;
    void Awake()
    {
        rewardSelector = new RewardSelector(catalog);
    }
    public void ShowPanel()
    {
        NowSet();
        RewardSet();
        rewardPanel.SetActive(true);
    }
    public void HidePanel()
    {
        rewardPanel.SetActive(false);
    }
    void NowSet()
    {
        var weapons = _playerData.weapons;
        var effects = _playerData.effects;
        nowWeaponsUISet.WeaponSet(weapons,5);
        nowEffectSet.EffectSet(effects);
        weaponDataView.View(weapons,5);
    }
    void RewardSet()
    {
        var weapons = rewardSelector.Select(EnemyRank.Low);
        rewardWeaponsUISet.WeaponSet(weapons,3);
        rewardWeaponData.View(weapons,3);
    }


}