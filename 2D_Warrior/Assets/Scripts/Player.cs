using UnityEngine;

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
    [Header("開槍音效")]
    public AudioClip soundFire;
    [Header("血量"), Range(0, 2000)]
    public float hp = 100;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    /// <summary>
    /// 取得玩家水平軸向的值
    /// </summary>
    public float h;
    #endregion

    private void Start()
    {
        // GetComponent<泛型>()
        // 泛型：泛指所有類型
        // GetComponent<Animator>()
        // GetComponent<AudioSource>()

        // 剛體欄位 = 取得元件<剛體>()
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetHorizontal();
        Move();
    }

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
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {

    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Fire()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="getDamge">造成的傷害</param>
    private void Damage(float getDamge)
    {

    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }
    #endregion
}
