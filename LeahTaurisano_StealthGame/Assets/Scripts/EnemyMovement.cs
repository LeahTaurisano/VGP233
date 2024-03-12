using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float enemyStopDistance;

    private NavMeshAgent agent;
    private int waypointIndex;
    private Transform foundPlayer;
    private AIState currentState;

    private float wanderTimerMax = 10;
    private float wanderTimer = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = AIState.Patrol;
        agent.SetDestination(wayPoints[waypointIndex].position);
    }

    void Update()
    {
        if (currentState == AIState.Patrol)
        {
            Vector3 aiPosition = new Vector3(transform.position.x, wayPoints[waypointIndex].position.y, transform.position.z);
            Vector3 wayPointPosition = wayPoints[waypointIndex].position;
            float distanceFromWaypoint = Vector3.Distance(aiPosition, wayPointPosition);

            if (distanceFromWaypoint < 0.1f)
            {
                waypointIndex = (waypointIndex + 1) % wayPoints.Length;
            }
            if (tag == "Wander")
            {
                if (wanderTimer > wanderTimerMax)
                {
                    waypointIndex = Random.Range(0, wayPoints.Length);
                    wanderTimer = 0.0f;
                }
                else
                {
                    wanderTimer += Time.deltaTime;
                }
            }
            agent.SetDestination(wayPoints[waypointIndex].position);
        }
        else if (currentState == AIState.Chase)
        {
            agent.SetDestination(foundPlayer.position);
            float distanceFromPlayer = Vector3.Distance(foundPlayer.position, transform.position);

            if (distanceFromPlayer > enemyStopDistance)
            {
                currentState = AIState.Patrol;
            }
        }
    }

    public void FoundPlayer(Transform player)
    {
        foundPlayer = player;
        currentState = AIState.Chase;
    }
}

public enum AIState
{
    Patrol,
    Chase,
}
