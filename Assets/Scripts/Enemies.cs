using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




public class Enemies : MonoBehaviour
{
    public enum State
    {
        Advancing,
        Attacking
    }

    public State currentState;
    public Transform Enemy;

    public Transform Dojo;
    public Transform waypointParent;
    [Header("EnemyStats")]
    public int enemyDamage = 10;
    public float moveSpeed = 5f;
    public float stoppingDistance = 1f;
    public int enemyHealth = 150;
    public float attackTimer = 0f;

    //  private int currentIndex = 1;
    public Transform[] waypoints;
    public NavMeshAgent agent;
    public int randomWaypoint;

    // Use this for initialization
    public void Start()
    {
        waypointParent = GameObject.Find("EnemyWaypoints").transform;
        Dojo = GameObject.Find("DojoWaypoint").transform;

        //get position of waypoints
        PickPath();
        waypoints = waypointParent.GetComponentsInChildren<Transform>();

        agent = GetComponent<NavMeshAgent>();

        Advancing();
    }

    // Update is called once per frame
    public void Update()
    {
        //switch states between attacking doors etc and walking
        switch (currentState)
        {
            case State.Advancing:
                Advancing();
                break;
            default:
                Advancing();
                break;
        }

    }

    //the enemies walk to the waypoint 
    //will change state when encountering a collider for doors or something
    public void Advancing()
    {
        //call pickpath

        //point is waypoint

        Transform point = waypoints[randomWaypoint];


        float distance = Vector3.Distance(transform.position, point.position);

        //stop at the waypoint
        agent.SetDestination(point.position);

        //look in the direction of the waypoint
        //transform.LookAt(point.position);

        if (distance < stoppingDistance)
        {
            // Debug.Log("I am close to the waypoint");

            randomWaypoint = 4;

        }

    }
    //generate a random number between 1 and 3 to pick one of three waypoints to go towards on different paths
    public void PickPath()
    {
        randomWaypoint = Random.Range(1, 4);
    }
}


