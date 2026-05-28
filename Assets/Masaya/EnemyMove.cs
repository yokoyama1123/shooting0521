using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform center;   // © Inspector ‚Åİ’è‚·‚é’†S
    public float radius = 2f;  // ”¼Œa
    public float speed = 1f;   // ‰ñ“]‘¬“x

    private float angle = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (center == null)
        {
            Destroy(gameObject); // ’†S‚ª–¢İ’è‚È‚ç“®‚©‚È‚¢
        }
        angle += speed * Time.deltaTime;

        float x = center.position.x + Mathf.Cos(angle) * radius;
        float y = center.position.y + Mathf.Sin(angle) * radius;

        transform.position = new Vector2(x, y);
    }
}
