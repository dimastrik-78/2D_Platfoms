using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dest : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
