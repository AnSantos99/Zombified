using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine;

public class PatrollAgent : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;
    private int target = 0;

    public Transform playerPos;

    [SerializeField] private float remainingDistance = 0.5f;

    private NavMeshAgent agent;

    public AudioSource ad;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        NextPoint();

        //StartCoroutine(Wait());
    }

    void Update()
    {
        StartPath();
    }

    void NextPoint()
    {
        if (wayPoints.Length == 0)
        {
            return;
        }

        agent.destination = wayPoints[target].position;

        target = (target + 1) % wayPoints.Length;
    }

    void StartPath()
    {
        if (!agent.pathPending && agent.remainingDistance < remainingDistance)
        {
            NextPoint();
        }
    }

    void FollowPlayer()
    {
        if (playerPos == null)
        {
            return;
        }

        agent.destination = playerPos.position;
    }

    //private IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(300);
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Dooropen d = collision.collider.GetComponent<Dooropen>();

    //    if(d != null)
    //    {
    //        d.OpenDoor();
    //    }

    //    if (collision.collider.gameObject.tag.Equals("Player"))
    //    {
    //        PlayerMov Pm = collision.collider.GetComponent<PlayerMov>();
    //        Pm.Lives--;
    //        Pm.teleport(roomPoint.position);
    //    }
    //}
}
