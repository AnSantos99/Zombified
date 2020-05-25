using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour
{
   void Update()
   {
       transform.RotateAround(Vector3.zero,Vector3.right,10f*Time.deltaTime);
       transform.LookAt(Vector3.zero);
   }
}
