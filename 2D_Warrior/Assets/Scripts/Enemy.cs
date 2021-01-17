using UnityEngine;

// 第一次套用腳本時執行
// 添加元件(類型(元件)，類型(元件))
[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;
    [Header("攻擊範圍"), Range(0, 100)]
    public float rangeAtk = 10;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 10;
    [Header("血量"), Range(0, 5000)]
    public float hp = 2500;

    private Animator ani;
    private AudioSource aud;
    private Rigidbody2D rig;

    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收傷害值</param>
    public void Damage(float damage)
    {
        hp -= damage;                   // 遞減
        ani.SetTrigger("受傷觸發");      // 受傷動畫
    }
}
