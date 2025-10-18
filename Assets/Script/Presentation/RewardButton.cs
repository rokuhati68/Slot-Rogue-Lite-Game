using UnityEngine;
using UnityEngine.Events;
using System;
public class RewardButton : MonoBehaviour
{
    [SerializeField] int id;                   // このボタンのID（スロット番号や武器IDなど）
    public Action<int> OnClicked;

    public void Clicked() 
    {
        OnClicked?.Invoke(id);
    }
}
