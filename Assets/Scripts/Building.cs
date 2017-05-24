using UnityEngine;

public class Building : MonoBehaviour
{

    public int buildingHP = 3;
    public ParticleSystem explode;
    public GameObject scoreBoard;

    // Use this for initialization
    void Start()
    {
        scoreBoard = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (buildingHP <= 0)
        {
            scoreBoard.GetComponent<ScoreUpdater>().UpdateBuildingsDestroyed(1);
            scoreBoard.GetComponent<ScoreUpdater>().NotifyUser("Building Destroyed!");
            Instantiate<ParticleSystem>(explode, transform.position, transform.rotation,transform.parent);
            Destroy(gameObject);


        }
    }

    public bool TakeDamage(int d)
    {
        buildingHP -= d;
        return true;
    }
}
