using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        rb.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
