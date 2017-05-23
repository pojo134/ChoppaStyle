using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abduction : MonoBehaviour
{

    public Light ar;
    public ParticleSystem ps;
    private float abductSpeed;
    public GameObject scoreBoard;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        abductSpeed = 0;
        if (collider.transform.tag == "Enemy" && collider.gameObject.name.Contains("RedLaser") == false)
        {
            ar.enabled = true;
            ps.Play();

        }
    }
    private void OnTriggerStay(Collider collider)
    {
        abductSpeed += Time.deltaTime;
        if (abductSpeed >= 2 && collider.transform.tag == "Enemy" && collider.gameObject.name.Contains("RedLaser") == false)
        {
            Destroy(collider.gameObject);
            scoreBoard.GetComponent<ScoreUpdater>().UpdateSamples(1);
            scoreBoard.GetComponent<ScoreUpdater>().NotifyUser("Sample Collected");

            ar.enabled = false;
            ps.Stop();

        }
    }
    private void OnTriggerExit(Collider collider)
    {
        ar.enabled = false;
        ps.Stop();
    }

}
