using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public int O2 = 100;

    private bool water = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (water == false)
            if (O2 < 100)
                O2++;
        if (O2 > 100)
            O2 = 100;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
            water = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
            if (O2 > 0)
                O2--;
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
