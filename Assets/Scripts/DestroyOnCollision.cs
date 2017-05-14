using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    float timer;

    private void Awake()
    {
        timer = Time.time;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Enemy" && other.transform.tag != "ViewRange" && other.gameObject.name != "AbductionZone" && other.transform.tag != "Cursor")
        {
            Debug.Log(other.gameObject.name);
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Enemy" && collision.transform.tag != "Cursor" || gameObject.name.Contains("BlueLaser"))
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Time.time - timer > 1f)
        {
            Debug.Log("Airball");
            Destroy(gameObject);
        }
    }
}
