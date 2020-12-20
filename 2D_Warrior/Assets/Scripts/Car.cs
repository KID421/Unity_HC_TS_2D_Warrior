using UnityEngine;

public class Car : MonoBehaviour
{
    // 單行註解：不會被程式讀取
    // 欄位語法
    // 修飾詞 類型 名稱 (指定 值)；

    // 四大類型
    // 整數 int
    // 浮點數 float   小數點後面必須加上 f 或 F
    // 字串 string    必須用雙引號 "" 包覆住
    // 布林值 bool    是 true、否 false

    // 修飾詞
    // 私人：不會顯示 (預設) private
    // 公開：會顯示 public

    // 指定符號 =

    // 欄位屬性
    // 語法
    // [屬性名稱("字串或對應的值")]
    // 標題 Header
    // 提示 Tooltip
    // 範圍 Range
    [Header("高度")]
    [Range(1, 10)]
    public int height = 5;
    [Header("重量"), Tooltip("這是汽車的重量，單位是噸。"), Range(2.5f, 10.5f)]
    public float weight = 5.5f;
    [Header("品牌")]
    public string brand = "BMW";
    [Header("否有天窗")]
    public bool hasWindow = true;

    // 其他類型
    // 顏色 Color
    public Color myColor1;
    public Color red = Color.red;
    public Color blue = Color.blue;
    public Color myColor2 = new Color(0.5f, 0.3f, 0.1f);
    public Color myColor3 = new Color(0, 0.5f, 0.8f, 0.5f);

    // 座標 向量 2 - 4
    public Vector2 v2Zero = Vector2.zero;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2A = new Vector2(9, 10);

    public Vector3 v3A = new Vector3(1, 2, 3);
    public Vector4 v4A = new Vector4(1, 2, 3, 4);

    // 圖片 與 音效
    public Sprite picture;
    public AudioClip sound;

    // 遊戲物件 與 元件

    // 遊戲物件：儲存階層面板內的物件與預製物
    public GameObject objA;
    public GameObject objB;

    // 元件：屬性面板上可摺疊的元件
    public Transform tra;
    public Camera cam;
}
