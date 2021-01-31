using UnityEngine;

public class EnemySecondAttack : MonoBehaviour
{
    [Header("第二階段攻擊力")]
    public float attack = 50;

    // 事件：粒子碰撞事件
    // 必須勾選 Collision 與 Send Message
    private void OnParticleCollision(GameObject other)
    {
        // 如果 碰到的物件 有 Player 腳本就讓他受傷
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().Damage(attack);
        }
    }
}
