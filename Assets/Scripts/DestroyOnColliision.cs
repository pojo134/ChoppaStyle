using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnColliision : MonoBehaviour
{
    float timer;

    private void Awake()
    {
        timer = Time.time;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Time.time - timer > 0.5f)
        {
            Debug.Log("Airball");
            Destroy(gameObject);
        }
    }
}
