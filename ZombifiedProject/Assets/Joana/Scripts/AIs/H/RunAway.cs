using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunAway : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]private GameObject Player;

    [SerializeField]private float EnemyDistanceRun = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);


        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;

            agent.SetDestination(newPos);
        }
    }
}
