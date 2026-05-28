using UnityEngine;

public class FuMissileEnemy : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float intervalTime;
    [SerializeField] private float bulletSpeed;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = intervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > intervalTime)
        {
            timer = 0.0f;

            GameObject bullet1 =
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            GameObject bullet2 =
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            bullet1.GetComponent<Rigidbody2D>().
                AddForce(new Vector2(bulletSpeed, 0.0f), ForceMode2D.Impulse);

            bullet2.GetComponent<Rigidbody2D>().
                AddForce(new Vector2(-bulletSpeed, 0.0f), ForceMode2D.Impulse);

        }

    }
}
