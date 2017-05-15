using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{


    public int soldierHP = 3;
    public float range = 5f;
    public GameObject scoreBoard;
    public GameObject enemyLaser;
    public GameObject playerShip;
    public GameObject shotOne, shotTwo, shotThree;
    private Vector3 laserTarget;
    private bool detected;
    public float rotateSpeed;
    private float fireTimer;

    // Use this for initialization
    void Start()
    {
        scoreBoard = GameObject.FindGameObjectWithTag("Canvas");
        playerShip = GameObject.FindGameObjectWithTag("Player");
        detected = false;
    }

    internal void Detected(bool v)
    {
        Debug.Log("detected changed to: " + v);
        detected = v;
    }

    // Update is called once per frame
    void Update()
    {
        if (soldierHP <= 0)
        {
            scoreBoard.GetComponent<ScoreUpdater>().UpdateEvaporations(1);
            Destroy(gameObject);
        }
        if (detected)
        {
            float DistanceToPlane = Vector3.Dot(transform.TransformDirection(Vector3.up), playerShip.transform.position - transform.position);
            Vector3 plantPoint = playerShip.transform.position - transform.TransformDirection(Vector3.up) * DistanceToPlane;

            transform.LookAt(plantPoint, transform.TransformDirection(Vector3.up));

        }


    }



    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " collided with " + name);
        if (collision.gameObject.name.Contains("BlueLaser")) { soldierHP--; }

    }

    public void Fire()
    {
        if (shotOne == null)
        {
            laserTarget = playerShip.transform.position;
            shotOne = Instantiate(enemyLaser, new Vector3(transform.position.x, transform.position.y, transform.position.z - 3), Quaternion.identity);
            shotOne.transform.Rotate(-90, 0, 0);
        }
        else
        {
            shotOne.transform.position = Vector3.Slerp(shotOne.transform.position, laserTarget, Time.deltaTime * 5);

        }
    }
    internal void Fire(Collider other)
    {
        if (shotOne == null)
        {
            laserTarget = other.transform.position;
            shotOne = Instantiate(enemyLaser, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z - 2), transform.rotation);
            //shotOne.transform.LookAt(other.transform);
            //shotOne.transform.rotation *= Quaternion.Euler(0, 0, 90f);
            fireTimer = Time.fixedTime;
        }
        /*
        else if (shotTwo == null && shotOne != null)
        {
            laserTarget = other.transform.position;
            shotTwo = Instantiate(enemyLaser, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z - 2), transform.rotation);
            //shotOne.transform.LookAt(other.transform);
        }
        else if (shotThree == null && shotTwo != null && shotOne != null)
        {
            laserTarget = other.transform.position;
            shotThree = Instantiate(enemyLaser, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z - 2), transform.rotation);
            //shotOne.transform.LookAt(other.transform);
        }
        */
        else
        {
            shotOne.transform.position = Vector3.LerpUnclamped(shotOne.transform.position, laserTarget, Time.deltaTime * 5); 
            //if (shotTwo != null) shotTwo.transform.position = Vector3.LerpUnclamped(shotTwo.transform.position, laserTarget, Time.deltaTime * 5); 
            //if (shotThree != null) shotThree.transform.position = Vector3.LerpUnclamped(shotThree.transform.position, laserTarget, Time.deltaTime * 5); 

        }

    }
}
