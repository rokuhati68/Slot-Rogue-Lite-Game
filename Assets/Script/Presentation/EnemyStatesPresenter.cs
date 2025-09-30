using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyStatesPresenter:MonoBehaviour
{
    public Enemy _enemy;
    public EnemyView _view;
    public HPView _hpView;

    void OnEnable()
    {
        _enemy.EnemySet += OnEnemySet;
        _enemy.EnemyDamaged += OnDamaged;
    }

    void OnDisable()
    {
        _enemy.EnemySet -= OnEnemySet;
        _enemy.EnemyDamaged -= OnDamaged;
    }

    void OnEnemySet()
    {
        var hp = _enemy.HP;
        _view.StatusView(_enemy);
        _hpView.Set(hp);
    }
    void OnDamaged()
    {
        var hp = _enemy.HP;
        _hpView.TakeDamage(hp);
    }

    
}