using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10.5f;
    [Header("跳越高度"), Range(0, 3000)]
    public int jump = 100;
    [Header("是否在地板上"), Tooltip("判斷腳色是否在地面上")]
    public bool isGrounded;
    [Header("子彈")]
    public GameObject bullet;
    [Header("子彈生成點")]
    public Transform pointSpawn;
    [Header("子彈速度"), Range(0, 5000)]
    public int speedBullet = 800;
    [Header("子彈傷害"), Range(0, 5000)]
    public float damageBullet = 50;
    [Header("開槍音效")]
    public AudioClip soundFire;
    [Header("血量"), Range(0, 2000)]
    public float hp = 100;
    [Header("地面判定位移")]
    public Vector3 offset;
    [Header("地面判定半徑")]
    public float radius = 0.3f;
    [Header("鑰匙音效")]
    public AudioClip soundKey;
    [Header("血量文字")]
    public Text textHp;
    [Header("血量圖片")]
    public Image imgHp;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    private float hpMax;
    /// <summary>
    /// 取得玩家水平軸向的值
    /// </summary>
    private float h;
    #endregion

    #region 事件
    private void Start()
    {
        // GetComponent<泛型>()
        // 泛型：泛指所有類型
        // GetComponent<Animator>()
        // GetComponent<AudioSource>()

        // 剛體欄位 = 取得元件<剛體>()
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        hpMax = hp;
    }

    private void Update()
    {
        GetHorizontal();
        Move();
        Jump();
        Fire();
    }

    // 在 Unity 內繪製圖示
    private void OnDrawGizmos()
    {
        // 圖示.顏色 = 顏色
        Gizmos.color = new Color(1, 0, 0, 0.6f);
        // 圖示.繪製球體(中心點，半徑)
        Gizmos.DrawSphere(transform.position + offset, radius);
    }

    /// <summary>
    /// 觸發事件：Enter 進入時執行一次
    /// </summary>
    /// <param name="collision">碰到的物件資訊</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果 碰到物件的標籤 為  鑰匙
        if (collision.tag == "鑰匙")
        {
            // 刪除(一定要放 GameObject)
            Destroy(collision.gameObject);
            aud.PlayOneShot(soundKey, Random.Range(1.2f, 1.5f));
        }
    }
    #endregion

    #region 方法
    /// <summary>
    /// 取得水平軸向
    /// </summary>
    private void GetHorizontal()
    {
        // 輸入.取得軸向("水平")
        h = Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 剛體.加速度 = 二維(水平 * 速度，原本加速度的 Y)
        rig.velocity = new Vector2(h * speed, rig.velocity.y);

        // 如果 玩家 按下 D 或者 右鍵 就執行 { 內容 }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // transform 指的與此腳本同一層的 Transform 元件
            // Rotation 角度在程式是 localEulerAngles
            transform.localEulerAngles = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        // 動畫控制器.設定布林值(參數，布林值)
        // 玩家按下左或右時 跑步 h != 0
        ani.SetBool("跑步開關", h != 0);
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        // 如果 在地面上 並且 按下空白鍵 才可以 跳躍
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0, jump));         // 剛體.添加推力(二維向量)
            ani.SetTrigger("跳躍觸發");
        }

        // 碰撞物件 = 2D 物理.覆蓋圓形(中心點，半徑，圖層) - 1 << 圖層
        Collider2D hit = Physics2D.OverlapCircle(transform.position + offset, radius, 1 << 8);
        // 如果 碰到的物件 存在的 就將 是否在地面上 設定為 是
        if (hit)
        {
            isGrounded = true;
        }
        // 否則 沒有碰到物件 就將 是否在地面上 設定為 否
        else
        {
            isGrounded = false;                         // 不在地面上
        }

        ani.SetFloat("跳躍", rig.velocity.y);           // 動畫控制器.設定浮點數(參數，值)
        ani.SetBool("是否在地面上", isGrounded);
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Fire()
    {
        // 如果按下左鍵 (手機為觸控)
        if (Input.GetKeyDown(KeyCode.Mouse0))       
        {
            // 音效來源.播放一次音效(音效片段，音量)
            aud.PlayOneShot(soundFire, Random.Range(1.2f, 1.5f));
            // 區域變數 名稱 = 生成(物件，座標，角度)
            GameObject temp = Instantiate(bullet, pointSpawn.position, pointSpawn.rotation);
            // 暫存子彈.取得元件<剛體>().添加推力(生成點右邊 * 子彈速度 + 生成點上方 * 高度)
            temp.GetComponent<Rigidbody2D>().AddForce(pointSpawn.right * speedBullet + pointSpawn.up * 50);
            // 暫存子彈.添加元件<子彈>().攻擊力 = 子彈傷害
            temp.AddComponent<Bullet>().attack = damageBullet;
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="getDamge">造成的傷害</param>
    public void Damage(float getDamge)
    {
        hp -= getDamge;                 // 遞減
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
        enabled = false;
        transform.Find("槍").gameObject.SetActive(false);
    }
    #endregion
}
