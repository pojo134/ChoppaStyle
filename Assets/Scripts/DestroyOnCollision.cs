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
        if (other.transform.tag != "Enemy" && other.gameObject.name != "AbductionZone" && other.transform.tag != "Cursor")
        {
            Debug.Log(other.gameObject.name);
            Destroy(gameObject);
        }
        if (other.transform.tag == "Enemy" && gameObject.name.Contains("BlueLaser"))
        {
            other.transform.GetComponent<Soldier>().TakeDamage(1);
        }
        if (other.transform.tag == "Cow" && gameObject.name.Contains("BlueLaser"))
        {
            other.transform.GetComponent<Cow>().TakeDamage(1);
        }
        if (other.transform.tag == "Building" && gameObject.name.Contains("BlueLaser"))
        {
            other.transform.GetComponent<Building>().TakeDamage(1);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy"  && gameObject.name.Contains("RedLaser"))
        {
            Debug.Log("Shot Self");
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Enemy" && gameObject.name.Contains("BlueLaser"))
        {
            collision.transform.GetComponent<Soldier>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Cow" && gameObject.name.Contains("BlueLaser"))
        {
            collision.transform.GetComponent<Cow>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Building" && gameObject.name.Contains("BlueLaser"))
        {
            collision.transform.GetComponent<Building>().TakeDamage(1);
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
