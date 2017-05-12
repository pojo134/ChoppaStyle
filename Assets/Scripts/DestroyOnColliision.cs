using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnColliision : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.ToString());
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.ToString());
        Destroy(gameObject);
    }
}
