using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {

    public GameObject soldier;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Entered Detection Zone");

            soldier.GetComponent<Soldier>().Fire(other.transform);
            soldier.GetComponent<Soldier>().Detected(true);


        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Still in Detection Zone");

            soldier.GetComponent<Soldier>().Fire(other.transform);
            //soldier.GetComponent<Soldier>().Detected(true);

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Left Detection Zone");
            soldier.GetComponent<Soldier>().Detected(false);

        }

    }

}
