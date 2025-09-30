using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyView:MonoBehaviour
{
    public TextMeshProUGUI enemyName;
    public Image _image;
    public void StatusView(Enemy _enemy)
    {   
        var HP = _enemy.HP;
        var ATK = _enemy.ATK;
        var DFS = _enemy.DFS;
        var enemyImage = _enemy.Image;
        var Name = _enemy.Name;
        ImageView(enemyImage);
        NameView(Name);
    }
    void ImageView(Sprite enemyImage)
    {
        _image.sprite = enemyImage;
    }
    void NameView(string name)
    {
        enemyName.text = name;
    }
    
}