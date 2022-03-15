using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Heal = 10, coin = 0;
    public float MoveSpeed, JumpPower;
    public bool ChestAnim = false;

    public GameObject FireBallPref;
    public Transform FireBallPoint;
    public leg Legs;
    public Head head;

    public Rigidbody2D RBFireBall;
    public float FireBallSpeed;

    private bool attacks = false;
    private float BogMode = 0;
    private float Speed;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float firePointX;
    private Animator Anim;
    private Vector2 Vector;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Anim = transform.GetChild(0).GetComponent<Animator>();

        firePointX = FireBallPoint.localPosition.x;
    }
    void Update()
    {
        if (BogMode > 0)
            BogMode--;

        Anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Heal > 0)
        {
            if (head.O2 <= 0 && BogMode == 0)
            {
                Heal--;
                BogMode = 240;
            }

            if (rb.velocity.x > 0)
            {
                sprite.flipX = false;
                FireBallPoint.localPosition = new Vector2(firePointX, FireBallPoint.localPosition.y);
            }
            else if (rb.velocity.x < 0)
            {
                sprite.flipX = true;
                FireBallPoint.localPosition = new Vector2(-firePointX, FireBallPoint.localPosition.y);
            }

            Speed = Input.GetAxis("Horizontal") * MoveSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Legs.Grounded == true)
                    rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }

            if (Input.GetMouseButtonDown(0) && attacks == true)
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
        if (sprite.flipX == false)
            Vector = Vector2.right;
        else
            Vector = Vector2.left;
        GameObject FireBall = Instantiate(FireBallPref, FireBallPoint.position, Quaternion.identity);
        RBFireBall = FireBall.GetComponent<Rigidbody2D>();
        RBFireBall.AddForce(Vector * FireBallSpeed, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DEAD")
            Heal = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
            Heal--;
        if (collision.CompareTag("Coin"))
        {
            coin++;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Damage"))
        {
            if (BogMode <= 0)
            {
                Heal--;
                BogMode = 240;
            }
        }
        if (collision.CompareTag("attack"))
            if (Input.GetKeyDown(KeyCode.E))
            {
                attacks = true;
            }
    }
}
