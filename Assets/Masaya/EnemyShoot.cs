using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public Transform firePoint;     // 発射位置（Inspector で設定）

    public float fireInterval = 1.5f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
