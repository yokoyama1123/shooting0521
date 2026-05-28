using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // ê^â∫Ç…à⁄ìÆ
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
}
