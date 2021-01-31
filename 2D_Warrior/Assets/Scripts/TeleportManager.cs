using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    [Header("要傳送的另一個傳送門")]
    public Transform otherTeleport;

    private bool playerIn;
    private Transform player;       // 玩家變形元件

    /// <summary>
    /// 傳送方法
    /// </summary>
    private void Teleport()
    {
        if (playerIn && Input.GetKeyDown(KeyCode.W))                        // 如果 玩家進入 並且 按下 W
        {
            player.position = otherTeleport.position + Vector3.up * 2.5f;   // 玩家做標 = 另一個門 的 座標 + 位移 1.5
        }
    }

    private void Awake()
    {
        player = GameObject.Find("戰士").transform;       // 尋找遊戲物件
    }

    private void Update()
    {
        Teleport();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "戰士") playerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "戰士") playerIn = false;
    }
}
