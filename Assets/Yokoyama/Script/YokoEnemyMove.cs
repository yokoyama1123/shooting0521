using UnityEngine;

public class YokoEnemyMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;   // 移動速度
    [SerializeField] private bool moveRight = false;   // true:右へ, false:左へ

    void Update()
    {
        // 移動方向を決定
        float direction = 0;
        if (!moveRight)
        { 
            direction = 1f; 
        }
        if (moveRight) 
        {
            direction = -1f; 
        }

        // 平行移動
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        //X座標が行きすぎたら消滅
        if(!moveRight && gameObject.transform.position.x >= 10)
        {
            Destroy(gameObject);  // 自分自身を消す
        }
        if (moveRight && gameObject.transform.position.x <= -10)
        {
            Destroy(gameObject);  // 自分自身を消す
        }

    }

    // 衝突判定（2Dの場合）
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);  // 自分自身を消す
        }
    }

    // または、トリガー判定を使う場合（IsTriggerが必要）
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);  // 自分自身を消す
        }
    }
}
