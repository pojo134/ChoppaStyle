using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveGrass : MonoBehaviour {

    private Vector3 lastPos;
    private Vector3 parentTransform;
    private ParticleSystem ps;

    // Use this for initialization
    void Start () {
        ps = GetComponent<ParticleSystem>();
        parentTransform = GetComponentInParent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == lastPos && ps.isPlaying == false)
        {
            ps.Play();
            //Debug.Log("Play");
        }
        else if (transform.position == lastPos && ps.isPlaying == true)
        {
            //Debug.Log("Playing");
        }
        else
        {
            lastPos = transform.position;
            ps.Stop();
            ps.Clear();
            //Debug.Log("Moving");
        }
    }
}
