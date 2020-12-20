using UnityEngine;

public class Car : MonoBehaviour
{
    // 單行註解：不會被程式讀取
    // 欄位語法
    // 修飾詞 類型 名稱 (指定 值)；

    // 四大類型
    // 整數 int
    // 浮點數 float
    // 字串 string
    // 布林值 bool

    // 修飾詞
    // 私人：不會顯示 (預設) private
    // 公開：會顯示 public

    // 指定符號 =

    // 欄位屬性
    // 語法
    // [屬性名稱("字串或對應的值")]
    [Header("這是汽車的高度")]
    public int height = 5;
    [Tooltip("這是汽車的重量，單位是噸。")]
    public float weight = 5.5f;
    [Header("這是汽車的品牌")]
    public string brand = "BMW";
    [Header("這是汽車是否有天窗")]
    public bool hasWindow = true;
    // 是 true
    // 否 false
}
