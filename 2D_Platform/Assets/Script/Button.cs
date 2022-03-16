using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Open;
    public GameObject PrefDeath;

    private float PointX;
    void Start()
    {
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OpenBox")
            Open.SetActive(true);
        if (collision.gameObject.tag == "Player")
        {
            PrefDeath.SetActive(true);
        }
    }
}
