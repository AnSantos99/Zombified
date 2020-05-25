using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotSpeed = 100f;

    [SerializeField] private bool isWandering = false;
    [SerializeField] private bool isRotatingLeft = false;
    [SerializeField] private bool isRotatingRight = false;
    [SerializeField] private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }

        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }

        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }

        if (isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);       //How long it rotates
        int rotateWait = Random.Range(1, 3);    //time in between each time it rotates
        int rotateLorR = Random.Range(0, 3);    //LorR = Left or Right
        int walkWait = Random.Range(1, 3);      //time in between walking
        int walkTime = Random.Range(1, 5);      //how long it walks

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;

        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        yield return new WaitForSeconds(rotateWait);

        if(rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }

        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;
    }
}
