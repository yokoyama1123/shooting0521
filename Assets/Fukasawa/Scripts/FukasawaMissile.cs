using UnityEngine;

public class FukasawaMissile : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;

    private Vector2 moveDirection;
    private Transform playerTransform;
    private new Rigidbody2D rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 targetDire = playerTransform.position - transform.position;
        targetDire.Normalize();

        rigidbody.AddForce(targetDire * moveSpeed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
