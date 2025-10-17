using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RewardManager:MonoBehaviour
{
    public GameObject rewardPanel;
    public WeaponsUISet nowWeaponsUISet;
    public WeaponsUISet rewardWeaponsUISet;
    public BattleEffectSet nowEffectSet;
    public BattleEffectSet rewardEffectSet;
    public PlayerData _playerData;
    public TextMeshProUGUI[] status;
    public WeaponDataView weaponDataView;
    public void ShowPanel()
    {
        nowSet();
        rewardPanel.SetActive(true);
    }
    public void HidePanel()
    {
        rewardPanel.SetActive(false);
    }
    void nowSet()
    {
        var weapons = _playerData.weapons;
        var effects = _playerData.effects;
        nowWeaponsUISet.WeaponSet(weapons);
        nowEffectSet.EffectSet(effects);
        weaponDataView.View(weapons,5);
    }


}