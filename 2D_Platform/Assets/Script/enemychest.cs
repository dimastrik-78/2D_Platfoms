using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemychest : MonoBehaviour
{
    public GameObject ArrowPref;
    public Transform ArrowPoint;
    public Rigidbody2D RBArrow;
    public float ArrowSpeed;

    private int Timer = 500;
    private float ArrowPointX;
    private SpriteRenderer sprite;
    private Vector2 Vector;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        ArrowPointX = ArrowPoint.localPosition.x;

        if (sprite.flipX == true)
            ArrowPoint.localPosition = new Vector2(-ArrowPointX, ArrowPoint.localPosition.y);
        else
            ArrowPoint.localPosition = new Vector2(ArrowPointX, ArrowPoint.localPosition.y);

        if (sprite.flipX == false)
            Vector = Vector2.right;
        else
            Vector = Vector2.left;
    }
    void Update()
    {
        Timer--;
        if (Timer <= 0)
        {
            GameObject Arrow = Instantiate(ArrowPref, ArrowPoint.position, Quaternion.identity);
            RBArrow = Arrow.GetComponent<Rigidbody2D>();
            RBArrow.AddForce(Vector * ArrowSpeed, ForceMode2D.Impulse);
            Timer = 500;
        }
    }
}