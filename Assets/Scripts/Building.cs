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
            Instantiate<ParticleSystem>(explode, transform.position, transform.rotation);
            Destroy(gameObject);


        }
    }
    /*Taking damamge backwards, new method is TakeDamage()
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        buildingHP--;
    }
    */

    public bool TakeDamage(int d)
    {
        buildingHP -= d;
        return true;
    }
}
