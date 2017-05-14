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
            Debug.Log("Exploded");
            Instantiate<ParticleSystem>(explode, transform.position, transform.rotation);
            Destroy(gameObject);


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        buildingHP--;
    }
}
