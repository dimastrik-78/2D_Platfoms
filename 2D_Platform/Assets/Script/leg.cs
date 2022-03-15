using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leg : MonoBehaviour
{
    public bool Grounded;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded" || collision.gameObject.tag == "OpenBox")
            Grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded" || collision.gameObject.tag == "OpenBox")
            Grounded = true;
    }
}
