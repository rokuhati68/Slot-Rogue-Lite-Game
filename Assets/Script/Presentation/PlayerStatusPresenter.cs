using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerStatusPresenter:MonoBehaviour
{
    public Player _player;
    public HPView _hpView;

    void OnEnable()
    {
        _player.PlayerSet += OnPlayerSet;
        _player.PlayerDamaged += OnDamaged;
    }

    void OnDisable()
    {
        _player.PlayerSet -= OnPlayerSet;
        _player.PlayerDamaged -= OnDamaged;
    }

    void OnPlayerSet()
    {
        var hp = _player.HP;
        _hpView.Set(hp);
    }
    void OnDamaged()
    {
        var hp = _player.HP;
        _hpView.TakeDamage(hp);
    }

    
}