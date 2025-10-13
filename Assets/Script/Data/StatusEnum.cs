
public enum StatusPolarity { Positive, Negative, Neutral }
public enum ElementType { None, Fire, Water, Wind, Light, Dark }

// あなたのユニットが満たす最小インターフェース
public interface IUnit
{
    int MaxHP { get; }
    int HP { get; set; }
    int ATK{ get; }
    int DFS{ get; }
    ElementType Element { get; } // 使わないなら仮に None を返してOK
    bool Damaged(int damage);
}