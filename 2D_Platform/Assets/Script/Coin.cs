using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject Des1;
    public GameObject Des2;
    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Des1.SetActive(false);
            Des2.SetActive(false);
        }
    }
}
