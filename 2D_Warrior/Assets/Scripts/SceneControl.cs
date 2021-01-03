using UnityEngine;
using UnityEngine.SceneManagement;  // 引用 場景管理 API

public class SceneControl : MonoBehaviour
{
    // 1. 方法要讓按鈕呼叫必須設為公開 public

    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        // 2. 必須將場景放在 File > Build Settings...
        // 場景管理器.載入場景("場景名稱")；
        SceneManager.LoadScene("遊戲場景");
    }

    /// <summary>
    /// 返回選單
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene("選單");
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        // 應用程式.離開()
        Application.Quit();
    }
}
