using UnityEngine;
using System.Collections;       // 引用 系統.集合 API

public class CameraControl2D : MonoBehaviour
{
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 3.5f;
    [Header("晃動間隔"), Range(0, 1)]
    public float shakeInterval = 0.05f;
    [Header("晃動值"), Range(0, 5)]
    public float shakeValue = 0.5f;
    [Header("晃動次數"), Range(0, 10)]
    public int shakeCount = 3;

    /// <summary>
    /// 追蹤目標物件
    /// </summary>
    private void Track()
    {
        Vector3 posA = target.position;                                         // 取得玩家座標
        Vector3 posB = transform.position;                                      // 取得攝影機座標
        posA.z = -10;                                                           // Z 軸改為 -10

        posB = Vector3.Lerp(posB, posA, 0.5f * speed * Time.deltaTime);         // 差值 - Time.deltaTime 一幀的時間 - 此裝置一個影格的時間
        transform.position = posB;                                              // 更新攝影機座標
    }

    // 延遲更新：在 Update 執行後才執行，追蹤
    private void LateUpdate()
    {
        Track();
    }

    /// <summary>
    /// 晃動效果
    /// </summary>
    public IEnumerator ShakeCamera()
    {
        for (int i = 0; i < shakeCount; i++)
        {
            transform.position += Vector3.up * shakeValue;
            yield return new WaitForSeconds(shakeInterval);
            transform.position -= Vector3.up * shakeValue;
            yield return new WaitForSeconds(shakeInterval);
        }
    }
}
