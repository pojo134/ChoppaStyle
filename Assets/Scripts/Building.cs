using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public int buildingHP = 3;
    public ParticleSystem explode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (buildingHP <= 0) {
            Instantiate<ParticleSystem>(explode, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        buildingHP--;
    }
}
