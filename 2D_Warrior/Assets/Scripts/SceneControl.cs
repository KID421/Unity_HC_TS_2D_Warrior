using UnityEngine;
using UnityEngine.SceneManagement;  // 引用 場景管理 API

// C# : 繼承
// 擁有此類別的成員 - 欄位、屬性、方法以及事件
public class SceneControl : MonoBehaviour
{
    [Header("音效來源")]
    public AudioSource aud;
    [Header("按鈕音效")]
    public AudioClip soundClick;

    // 1. 方法要讓按鈕呼叫必須設為公開 public

    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        // 音效來源.播放一次(音效，音量)
        aud.PlayOneShot(soundClick, 2);
        // 延遲呼叫("方法名稱"，延遲秒數)
        Invoke("DelayStartGame", 1.5f);
    }

    /// <summary>
    /// 返回選單
    /// </summary>
    public void BackToMenu()
    {
        Time.timeScale = 1;
        aud.PlayOneShot(soundClick, 2);
        Invoke("DelayBackToMenu", 1.5f);
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        Time.timeScale = 1;
        aud.PlayOneShot(soundClick, 2);
        Invoke("DelayQuitGame", 1.5f);
    }

    /// <summary>
    /// 延遲開始遊戲
    /// </summary>
    private void DelayStartGame()
    {
        // 2. 必須將場景放在 File > Build Settings...
        // 場景管理器.載入場景("場景名稱")；
        SceneManager.LoadScene("遊戲場景");
    }

    /// <summary>
    /// 延遲返回選單
    /// </summary>
    private void DelayBackToMenu()
    {
        SceneManager.LoadScene("選單");
    }

    /// <summary>
    /// 延遲離開遊戲
    /// </summary>
    private void DelayQuitGame()
    {
        // 應用程式.離開()
        Application.Quit();
    }
}
