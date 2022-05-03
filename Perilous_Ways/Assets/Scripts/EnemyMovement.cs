using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // public Camera cam;
    // public Transform aimTransform;
[SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    //  public Animator anim;

    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f )
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }                   
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime*speed);

        // Vector3 relativePos = waypoints[currentWaypointIndex].transform.position - transform.position;
        // transform.rotation = Quaternion.LookRotation (relativePos); 

        // Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        // Vector3 aimDirection = (mousePosition - transform.position).normalized;
        // float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        // aimTransform.eulerAngles = new Vector3(0, 0, angle);

    }
}
