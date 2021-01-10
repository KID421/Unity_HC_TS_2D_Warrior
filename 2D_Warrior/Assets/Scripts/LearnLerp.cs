using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    public float a = 0;
    public float b = 100;

    public Vector2 v2A = new Vector2(0, 0);
    public Vector2 v2B = new Vector2(100, 100);

    private void Start()
    {
        // 差值結果 = 數學.差值(A，B，百分比)
        // 百分比介於 0 - 1 之間
        float result = Mathf.Lerp(0, 100, 0.2f);
        print("0 與 100 差值結果：" + result);
    }

    private void Update()
    {
        a = Mathf.Lerp(a, b, 0.5f);

        v2A = Vector2.Lerp(v2A, v2B, 0.5f);
    }
}
