using UnityEngine;

public class API : MonoBehaviour
{
    // 修飾詞 類別 欄位
    public Transform traA;
    public Transform tester;

    public Camera cam;

    public SpriteRenderer spr;
    public GameObject gam;

    private void Start()
    {
        // 非靜態屬性
        // 取得：
        // 欄位.屬性
        print("座標：" + traA.position);

        // 設定：
        // 欄位.屬性 指定 值；
        tester.position = new Vector3(2, 0, 0);

        // 靜態屬性
        print("攝影機數量：" + Camera.allCamerasCount);
        // 非靜態屬性
        cam.backgroundColor = new Color(0.5f, 0.2f, 0.3f);

        // 練習
        print("圖片顏色：" + spr.color);
        print("物件圖層：" + gam.layer);

        spr.flipX = true;
        gam.layer = 5;
    }

    private void Update()
    {
        // 非靜態方法
        // 使用：
        // 欄位.方法(對應的引數)；
        tester.Rotate(0, 0, 30);

        // 練習
        // 位移(X，Y，Z，空間)
        // World 世界
        // Self 區域
        tester.Translate(0.5f, 0, 0, Space.World);
    }
}
