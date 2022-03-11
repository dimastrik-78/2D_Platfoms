using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Heal;
    public float MoveSpeed, JumpPower;

    public GameObject bulletPrefab;
    public Transform firePoint;
    private float BogMode = 0;
    private int O2 = 100;
    private bool water = false;
    private float Speed;
    private bool Grounded;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float firePointX;
    private Animator Anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Anim = transform.GetChild(0).GetComponent<Animator>();

        firePointX = firePoint.localPosition.x;
    }
    void Update()
    {
        if (BogMode > 0)
            BogMode--;
        if (water == false)
            if (O2 != 100)
                O2++;

        if (Heal > 0)
        {
            if (rb.velocity.x > 0)
            {
                sprite.flipX = false;
                firePoint.localPosition = new Vector2(firePointX, firePoint.localPosition.y);
            }
            else if (rb.velocity.x < 0)
            {
                sprite.flipX = true;
                firePoint.localPosition = new Vector2(-firePointX, firePoint.localPosition.y);
            }

            Speed = Input.GetAxis("Horizontal") * MoveSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Grounded == true)
                    rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }

            if (Input.GetMouseButtonDown(0))
                Shoot();
        }
    }
    void FixedUpdate()
    {
        if (Heal > 0)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
        }
    }
    private void Shoot()
    {
        GameObject FireBall = Instantiate(bulletPrefab, firePoint);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
            Grounded = true;
        if (collision.gameObject.tag == "DEAD")
            Heal = 0;
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
        if (collision.CompareTag("water"))
        {
            water = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Damage"))
        {
            if (BogMode == 0)
            {
                Heal--;
                BogMode = 240;
            }
        }
        if (collision.CompareTag("water"))
        {
            O2--;
            if (O2 <= 0 && BogMode == 0)
            {
                Heal--;
                BogMode = 240;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
            water = false;
        }
    }
}
