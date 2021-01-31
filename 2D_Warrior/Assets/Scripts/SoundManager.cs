using UnityEngine;
using UnityEngine.Audio;    // 引用 音源 API

public class SoundManager : MonoBehaviour
{
    [Header("音源管理")]
    public AudioMixer mixer;

    /// <summary>
    /// 背景音樂 音量
    /// </summary>
    public void VolumeBGM(float v)
    {
        // 音源管理.設定浮點數("曝光參數名稱"，值)
        mixer.SetFloat("VolumeBGM", v);
    }

    /// <summary>
    /// 音效 音量
    /// </summary>
    public void VolumeSFX(float v)
    {
        mixer.SetFloat("VolumeSFX", v);
    }
}
