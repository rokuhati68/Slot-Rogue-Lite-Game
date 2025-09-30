public enum StatusKind { Poison /* 他は後で追加 */ }
public enum StatusPolarity { Positive, Negative, Neutral }
public enum ElementType { None, Fire, Water, Wind, Earth, Light, Dark }

// あなたのユニットが満たす最小インターフェース
public interface IUnit
{
    int MaxHP { get; }
    int HP { get; set; }
    ElementType Element { get; } // 使わないなら仮に None を返してOK
    bool Damaged(int damage);
}