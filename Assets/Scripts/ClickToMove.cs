using UnityEngine;
using System.Collections;


public class ClickToMove : MonoBehaviour
{

    public Transform playerShip, cursor;
    private float targetLat;
    private float targetLon;
    private float currentLat;
    private float currentLon;
    public float moveSpeed;
    public GameObject playerLaser;
    private Vector3 laserTarget;

    // Use this for initialization
    void Awake()
    {

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
        }

        //Fire laser to cursor location

        if (Input.GetMouseButtonDown(1))
        {
            laserTarget = hit.point;
            playerLaser = Instantiate(playerLaser, new Vector3(playerShip.position.x, playerShip.position.y, playerShip.position.z + 1), playerShip.rotation);
            playerLaser.transform.LookAt(laserTarget);

        }
        if (laserTarget != Vector3.zero)
        {
            playerLaser.transform.position = Vector3.Lerp(playerLaser.transform.position, new Vector3(laserTarget.x, laserTarget.y, laserTarget.z + 0.6f), Time.deltaTime * 5);
        }
    }

}

