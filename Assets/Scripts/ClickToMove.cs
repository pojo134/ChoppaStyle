using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ClickToMove : MonoBehaviour
{

    public Transform playerShip, cursor;
    public LineRenderer laserLine;
    private float targetLat;
    private float targetLon;
    private float currentLat;
    private float currentLon;
    public float moveSpeed;
    public GameObject playerLaser;
    private GameObject shotOne;
    private Vector3 laserTarget;
    public GameObject cow, building, soldier;
    public ParticleSystem laserBurn;
    public bool superLaserEnabled = true;
    public float bonusLength = 10f, bonusTimer = 0;
    public GameObject scoreBoard;


    // Use this for initialization
    void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 cowPoint = UnityEngine.Random.onUnitSphere * 60;
            Vector3 buildingPoint = UnityEngine.Random.onUnitSphere * 61.1f;
            Vector3 soldierPoint = UnityEngine.Random.onUnitSphere * 60;
            GameObject cowGO = Instantiate(cow, cowPoint, Quaternion.identity, this.transform);
            GameObject buildingGO = Instantiate(building, buildingPoint, Quaternion.identity, this.transform);
            GameObject soldierGO = Instantiate(soldier, soldierPoint, Quaternion.identity, this.transform);
            cowGO.transform.LookAt(Vector3.zero);
            buildingGO.transform.LookAt(Vector3.zero);
            buildingGO.transform.Rotate(-90, 0, 0);
            soldierGO.transform.LookAt(Vector3.zero);
            soldierGO.transform.Rotate(-90, 0, 0);
        }

    }
    private void Start()
    {
        laserLine = playerShip.GetComponentInParent<LineRenderer>();
        laserLine.startWidth = 0.2f;
        laserLine.enabled = false;

        scoreBoard = GameObject.FindGameObjectWithTag("Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        // perform raycast to get a point on the sphere
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (GetComponent<Collider>().Raycast(ray, out hit, float.PositiveInfinity))
        {
            // draw a line in the editor to visualize the hit point
            Debug.DrawRay(hit.point, hit.normal, Color.yellow);

            // convert the hit point into local coordinates
            Vector3 localPos = transform.InverseTransformPoint(hit.point);
            Vector3 longDir = localPos;
            // zero y to project the vector to the x-z-plane
            longDir.y = 0;

            //calculate the angle between our reference and the hitpoint
            float longitude = Vector3.Angle(-Vector3.forward, longDir);
            // if our point is on the western hemisphere negate the angle
            if (longDir.x < 0)
                longitude = -longitude;
            // calculate the latitude in degree
            float latitude = Mathf.Asin(localPos.normalized.y) * Mathf.Rad2Deg;

            cursor.position = hit.point;
            cursor.transform.LookAt(Vector3.zero);
            if (Input.GetMouseButtonDown(0))
            {
                targetLat = latitude;
                targetLon = longitude;

            }
        }

        // slowly move the currentLat / Lon towards our targetLat / Lon
        currentLat = Mathf.LerpAngle(currentLat, targetLat, Time.deltaTime * moveSpeed);
        currentLon = Mathf.LerpAngle(currentLon, targetLon, Time.deltaTime * moveSpeed);

        // build our rotation from the two angles
        transform.localRotation =
            Quaternion.AngleAxis(-currentLat, Vector3.right) *
            Quaternion.AngleAxis(currentLon, Vector3.up);


        //Move player ship to face cursor
        if (hit.point != Vector3.zero)
        {
            playerShip.transform.rotation = Quaternion.LookRotation(hit.point, Vector3.back);
            playerShip.transform.Rotate(new Vector3(90, 0, 0));
        }

        //Fire laser to cursor location
        if (superLaserEnabled)
        {
            scoreBoard.GetComponent<ScoreUpdater>().NotifyUser("Super Laser Enabled! " + Math.Abs(bonusTimer).ToString("F2"));

            if (shotOne != null)
            {
                shotOne.SetActive(false);

            }
            laserLine.SetPosition(0, playerShip.position);
            laserLine.SetPosition(1, cursor.position);
            if (Input.GetMouseButton(1))
            {
                RaycastHit laserHit;


                laserBurn.Play();
                laserLine.enabled = true;

                var heading = cursor.position - playerShip.position;
                //heading.y = 0;  // This is the overground heading.
                if (Physics.Raycast(playerShip.transform.position, heading, out laserHit))
                {
                    if (laserHit.transform != null)
                    {


                        if (laserHit.transform.tag == "Enemy")
                        {
                            laserHit.transform.GetComponent<Soldier>().TakeDamage(1);
                        }
                        if (laserHit.transform.tag == "Building")
                        {
                            laserHit.transform.GetComponent<Building>().TakeDamage(1);
                        }
                    }
                }

                /*
               
                 */
            }
            if (!Input.GetMouseButton(1))
            {
                laserLine.enabled = false;
                laserBurn.Stop();
            }
        }
        if(!superLaserEnabled)
        {
            

            laserLine.enabled = false;

            if (Input.GetMouseButton(1))
            {
                if (shotOne == null)
                {
                    laserTarget = hit.point;
                    shotOne = Instantiate(playerLaser, new Vector3(playerShip.position.x, playerShip.position.y, playerShip.position.z + 2), playerShip.rotation);

                }

            }
            if (laserTarget != Vector3.zero)
            {
                if (shotOne != null)
                {
                    shotOne.transform.position = Vector3.Slerp(shotOne.transform.position, new Vector3(laserTarget.x, laserTarget.y, laserTarget.z), Time.deltaTime * 5);
                }
            }
        }
        if (bonusTimer >= 100)
        {
            bonusTimer = 0;
        }
        bonusTimer += Time.deltaTime;
        if (bonusTimer <= 0)
        {
            superLaserEnabled = true;

        }
        else superLaserEnabled = false;
    }

    public void BonusMode()
    {
        bonusTimer = -bonusLength;

    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

