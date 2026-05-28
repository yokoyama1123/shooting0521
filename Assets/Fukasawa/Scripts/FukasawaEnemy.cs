using UnityEngine;

public class FukasawaEnemy : MonoBehaviour
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

            GameObject bullet = 
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().
                AddForce(new Vector2(0.0f, -bulletSpeed), ForceMode2D.Impulse);
        }
    }
}
