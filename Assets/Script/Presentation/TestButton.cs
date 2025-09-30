using UnityEngine;
using UnityEngine.UI;

public class TestButton:MonoBehaviour
{
    public Button button;
    public Reel ui;
    public void Onclick()
    {
        
        StartCoroutine(ui.SpinSlot(2));
    }
}