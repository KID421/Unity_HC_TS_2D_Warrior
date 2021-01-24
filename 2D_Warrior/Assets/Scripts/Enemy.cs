using UnityEngine;
using UnityEngine.UI;           // 引用 介面 API

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
    [Header("血量文字")]
    public Text textHp;
    [Header("血量圖片")]
    public Image imgHp;

    private Animator ani;
    private AudioSource aud;
    private Rigidbody2D rig;
    private float hpMax;
    private Player player;

    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        hpMax = hp;
        player = FindObjectOfType<Player>();    // 透過類型尋找物件<類型>() - 不能是重複物件
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收傷害值</param>
    public void Damage(float damage)
    {
        hp -= damage;                   // 遞減
        ani.SetTrigger("受傷觸發");      // 受傷動畫
        textHp.text = hp.ToString();    // 血量文字.文字內容 = 血量.轉字串()
        imgHp.fillAmount = hp / hpMax;  // 血量圖片.填滿長度 = 目前血量 / 最大血量

        if (hp <= 0) Dead();            // 如果 血量 <= 0 就 死亡
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        hp = 0;
        textHp.text = 0.ToString();
        ani.SetBool("死亡開關", true);
        
        GetComponent<CapsuleCollider2D>().enabled = false;      // 取得元件<膠囊碰撞>().啟動 = 關閉
        rig.Sleep();                                            // 剛體.睡著()
        rig.constraints = RigidbodyConstraints2D.FreezeAll;     // 剛體.約束 = 約束.凍結全部
    }

    /// <summary>
    /// 追蹤玩家與面向玩家
    /// </summary>
    private void Move()
    {
        AnimatorStateInfo asi = ani.GetCurrentAnimatorStateInfo(0);

        if (asi.IsName("骷髏受傷") || asi.IsName("骷髏攻擊")) return;

        /** 判斷式寫法
        if (transform.position.x > player.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        */

        // 三元運算子 - 布林值 ? 結果 1 : 結果 2

        // y = X 是否大於 玩家 X ? 是 y 為 180 : 否 y 為 0
        float y = transform.position.x > player.transform.position.x ? 180 : 0;
        transform.eulerAngles = new Vector3(0, y, 0);
        
        // 距離 = 二維.距離(A 座標，B 座標)
        float dis = Vector2.Distance(transform.position, player.transform.position);

        if (dis > rangeAtk)
        {
            // 剛體.移動座標(座標 + 前方 * 一幀 * 移動速度)
            rig.MovePosition(transform.position + transform.right * Time.deltaTime * speed);
        }
        else
        {
            Attack();
        }

        // 動畫.設定不林值("走路開關"，剛體.加速度.值 > 0)
        ani.SetBool("走路開關", rig.velocity.magnitude > 0);
    }

    /// <summary>
    /// 攻擊冷卻與攻擊行為
    /// </summary>
    private void Attack()
    {
        rig.velocity = Vector3.zero;
        ani.SetTrigger("攻擊觸發");
    }
}
