using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [Header("魔王血條")]
    public GameObject objHp;
    [Header("魔王")]
    public GameObject objBoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "戰士")
        {
            objHp.SetActive(true);
            objBoss.SetActive(true);
        }
    }
}
