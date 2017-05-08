using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") !=0)
        {
            this.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
        }
		
	}
}
