using UnityEngine;

public class LearnCSharp : MonoBehaviour
{
    public int a = 10;
    public int b = 3;

    private void Start()
    {
        // 比較運算子
        // 傳回布林值
        print(a > b);           // true
        print(a < b);           // false
        print(a == b);          // 等於 false
        print(a != b);          // 不等 true

        // 邏輯運算子
        // 並且 &&
        // 有一個 F 結果就是 F
        print(true && true);        // T
        print(true && false);       // F
        print(false && true);       // F
        print(false && false);      // F

        // 或者 ||
        // 有一個 T 結果就是 T
        print(true || true);        // T
        print(true || false);       // T
        print(false || true);       // T
        print(false || false);      // F
        
        // 相反 !
        print("相反運算子：" + (!true));      // F
        print("相反運算子：" + (!false));     // T
    }
}
