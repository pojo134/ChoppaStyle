using UnityEngine;
using System.Collections;


public class ClickToMove : MonoBehaviour
{

    public Transform playerShip,cursor;
    private float targetLat;
    private float targetLon;
    private float currentLat;
    private float currentLon;
    public float moveSpeed;

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
        playerShip.transform.rotation = Quaternion.LookRotation(hit.point, Vector3.back);
    }

}

