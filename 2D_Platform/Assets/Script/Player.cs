using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Heal;
    public float MoveSpeed, JumpPower;
    private float MoveX;
    private bool Grounded;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MoveX = Input.GetAxis("Horizontal") * MoveSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded == true)
                rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(MoveX, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
            Grounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
            Grounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
            Heal--;
    }
}
