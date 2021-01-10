using UnityEngine;

public class CameraControl2D : MonoBehaviour
{
    [Header("目標物件")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 3.5f;

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
}
