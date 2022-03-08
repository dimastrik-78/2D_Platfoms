using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Heal;
    public float MoveSpeed, JumpPower;
    public float BogMode = 0;

    private float Speed;
    private bool Grounded;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Transform AttackZone;
    private float AttackZoneX;
    private Animator Anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Anim = transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        if (BogMode > 0)
            BogMode--;

        //if (rb.velocity.x > 0)
        //{
        //    sprite.flipX = false;
        //    //AttackZone.localPosition = new Vector2(AttackZoneX, AttackZone.localPosition.y);
        //}
        //else if (rb.velocity.x < 0)
        //{
        //    //sprite.flipX = true;
        //    //AttackZone.localPosition = new Vector2(-AttackZoneX, AttackZone.localPosition.y);
        //}

        Speed = Input.GetAxis("Horizontal") * MoveSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded == true)
                rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Speed, rb.velocity.y);
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
