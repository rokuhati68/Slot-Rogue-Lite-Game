using UnityEngine;
using System;
public class PlayerUseCase:MonoBehaviour
{
    
    Player _player;
    PlayerData _playerData;
    WeaponsUISet _playerWeaponsSet;
    BattleEffectSet _battleEffectSet;
    WeaponSlot _playerWeaponSlot;
    EffectSlot _playerEffectSlot;
    public PlayerUseCase(Player player, PlayerData playerData, WeaponsUISet playerWeaponsSet
                        , BattleEffectSet battleEffectSet, WeaponSlot playerWeaponSlot, EffectSlot playerEffectSlot)
    {
        _player = player;
        _playerData = playerData;
        _playerWeaponsSet = playerWeaponsSet;
        _battleEffectSet = battleEffectSet;
        _playerWeaponSlot = playerWeaponSlot;
        _playerEffectSlot = playerEffectSlot;
    }


    public void PlayerSet()
    {

        _player.Set(_playerData.HP, _playerData.ATK,_playerData.DFS);
        _playerWeaponsSet.WeaponSet(_playerData.weapons);
        _battleEffectSet.EffectSet(_playerData.effects);
        _playerWeaponSlot.WeaponSet(_playerData.weapons);
        _playerEffectSlot.EffectSet(_playerData.effects);
    }
};