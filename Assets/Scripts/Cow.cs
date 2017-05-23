using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour {
    public int cowHP = 2;
    public GameObject scoreBoard;

    // Use this for initialization
    void Start () {
        scoreBoard = GameObject.FindGameObjectWithTag("Canvas");
    }
	
	// Update is called once per frame
	void Update () {
        if (cowHP <= 0)
        {
            scoreBoard.GetComponent<ScoreUpdater>().UpdateEvaporations(1);
            scoreBoard.GetComponent<ScoreUpdater>().NotifyUser("Cow Evaporated!");
            Destroy(gameObject);
        }
    }
    public bool TakeDamage(int d)
    {
        cowHP -= d;
        return true;
    }
}
