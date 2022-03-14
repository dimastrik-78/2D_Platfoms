using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject Destoy;
    public GameObject Pref1;
    public GameObject Pref2;
    public GameObject Pref3;
    public Transform point;
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
            GameObject Doc1 = Instantiate(Pref1, point.position, Quaternion.identity);
            GameObject Doc2 = Instantiate(Pref2, point.position, Quaternion.identity);
            GameObject Doc3 = Instantiate(Pref3, point.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
