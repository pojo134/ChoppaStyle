using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abduction : MonoBehaviour
{

    public Light ar;
    public ParticleSystem ps;
    public float abductSpeed;
    public int samples = 0, evaps = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        abductSpeed = 0;
        if (collision.transform.tag == "Enemy")
        {
            ar.enabled = true;
            ps.Play();

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        abductSpeed += Time.deltaTime;
        if (abductSpeed >= 2)
        {
            Destroy(collision.gameObject);
            samples++;
            ar.enabled = false;
            ps.Stop();
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        ar.enabled = false;
        ps.Stop();
    }
}
