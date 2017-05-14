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
    public GameObject shotOne;
    private Vector3 laserTarget;

    // Use this for initialization
    void Start()
    {
        scoreBoard = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (soldierHP <= 0)
        {
            scoreBoard.GetComponent<ScoreUpdater>().UpdateEvaporations(1);
            Destroy(gameObject);
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
            shotOne = Instantiate(enemyLaser, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z - 2), transform.rotation);
            shotOne.transform.LookAt(laserTarget);
        }
        else
        {
            shotOne.transform.position = Vector3.LerpUnclamped(shotOne.transform.position, laserTarget, Time.deltaTime * 5);

        }
    }
}
