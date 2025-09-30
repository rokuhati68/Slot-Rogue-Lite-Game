using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI操作に必要

public class HPView : MonoBehaviour
{
    // プレイヤーの最大HPと現在のHP
    public int maxHp;
    private int currentHp;
    // スライダーの参照
    public Slider hpSlider;

    public void Set(int startHP)
    {
        // 初期設定
        currentHp = startHP; // HPを最大値に設定
        hpSlider.maxValue = startHP; // スライダーの最大値を設定
        hpSlider.value = currentHp; // 現在のHPを反映
    }

    public void TakeDamage(int newHP)
    {
        // HPを減らす処理
        currentHp  = newHP;
        

        // スライダーに現在のHPを反映
        hpSlider.value = currentHp;

        // HPが0になったときの処理
    }
}