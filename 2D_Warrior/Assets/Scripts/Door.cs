using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("鑰匙")]
    public GameObject key;
    [Header("開門音效")]
    public AudioClip soundOpen;

    private Animator ani;
    private AudioSource aud;

    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果 玩家進入 並且 鑰匙 已被吃掉 就開門
        if (collision.name == "戰士" && key == null)
        {
            ani.SetTrigger("開門");
            aud.PlayOneShot(soundOpen, Random.Range(1.2f, 1.5f));
        }
    }
}
