using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{

    [SerializeField] private bool nightTime = false;
    [SerializeField] private bool inRefuge = false;

    Animator anim;

    public GameObject[] possibleWaypoint;
    List<Transform> path = new List<Transform>(); //array + index = prevents the bastard from going in circles between the points

    [SerializeField] private float rotSpeed = 0.8f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float accurracyWP = 2.0f;
    private int currentWP = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        foreach (GameObject go in possibleWaypoint)
        {
            path.Add(go.transform);
        }

        currentWP = FindClosestWP();
    }

    private int FindClosestWP()
    {
        if(path.Count == 0)
        {
            return -1;
        }

        int closest = 0;
        float lastDist = Vector3.Distance(this.transform.position,
                         path [0].position);
        for (int i = 1; i < path.Count; i++)
        {
            float thisDist = Vector3.Distance(this.transform.position,
                             path [i].position);
            if(lastDist > thisDist && i!= currentWP)
            {
                closest = i;
            }
        }
        return closest;
    }

    private void Update()
    {
        if (nightTime)
        {
            this.GetComponent<WanderingAI>().enabled = false;
            //this.GetComponent<PatrollAgent>().enabled = false;

            Vector3 direction = path[currentWP].position - transform.position;

            if (!inRefuge)
            {
                this.transform.rotation = Quaternion.Slerp(transform.rotation,
                                          Quaternion.LookRotation(direction),
                                          rotSpeed * Time.deltaTime);
                this.transform.Translate(0, 0, Time.deltaTime * speed);
                if (direction.magnitude < accurracyWP)
                {
                    path.Remove(path[currentWP]); //erases the one we've been to
                    currentWP = FindClosestWP();
                }
            }

            if (inRefuge)
            {
                if (direction.magnitude < accurracyWP)
                {
                    path.Remove(path[currentWP]); //erases the one we've been to
                    return;
                }
                //insert sleep sleep here :3
            }
        }

        if (!nightTime)  //if it's day they be wondering about
        {
            inRefuge = false;
            this.GetComponent<WanderingAI>().enabled = true;
            //this.GetComponent<PatrollAgent>().enabled = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Refuges" && nightTime)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        int walkTime = Random.Range(1, 4);

        yield return new WaitForSeconds(walkTime);

        inRefuge = true;
    }
}
