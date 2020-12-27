using UnityEngine;

/// <summary>
/// 認識 API 靜態 Static
/// </summary>
public class APIStatic : MonoBehaviour
{
    // 開始事件：播放時執行一次
    private void Start()
    {
        #region 靜態屬性存取
        // 屬性
        // 取得 靜態屬性
        // 語法：
        // 類別名稱.靜態屬性
        print("隨機值：" + Random.value);
        print("拍：" + Mathf.PI);

        // 設定 靜態屬性
        // 語法：
        // 類別名稱.靜態屬性 = 值；

        // 指標.可見 = 看不見
        Cursor.visible = false;

        // 如果有 Read Only 不能設定 - 唯讀
        // Time.deltaTime = 0.5f; // 錯誤

        // 時間.尺寸 = 2 倍速
        Time.timeScale = 2;
        #endregion

        // 使用 靜態方法
        // 語法：
        // 類別名稱.靜態方法(對應引數)；
        print("隨機值介於 100 - 500：" + Random.Range(100, 500));

        int number = Mathf.Abs(-99);
        print("取完絕對值的整數：" + number);

        // 練習區域：設定靜態屬性
        Physics2D.gravity = new Vector2(0, -20);

        // 練習區域：使用靜態方法
        Application.OpenURL("https://unity.com/");

        print("9.999 去小數點：" + Mathf.Floor(9.999f));

        print("兩點的距離：" + Vector3.Distance(new Vector3(1, 1, 1), new Vector3(22, 22, 22)));

        // 練習區域：取得靜態屬性
        print("攝影機數量：" + Camera.allCamerasCount);
        print("2D 重力：" + Physics2D.gravity);
    }

    // 更新事件：播放後一秒執行約 60 次
    // 60 FPS
    private void Update()
    {
        print("哈囉~");

        // 練習區域：取得靜態屬性
        print("是否按下任意鍵：" + Input.anyKeyDown);
        // print("遊戲時間：" + Time.time);

        print("是否按下空白鍵：" + Input.GetKeyDown("space"));
    }
}
