using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardingScript : MonoBehaviour
{
     [Header("Lock Desired Rotation")]
     [SerializeField] private bool lockX = true;
     [SerializeField] private bool lockY = false;
     [SerializeField] private bool lockZ = false;
     
     private Vector3 originalRotation;

     private void LateUpdate()
     {
          transform.LookAt(Camera.main.transform.position, Vector3.up);

          Vector3 rotation = transform.rotation.eulerAngles;
          if (lockX)
          {
               rotation.x = originalRotation.x;
          }
          if (lockY)
          {
               rotation.y = originalRotation.y;
          }
          if (lockZ)
          {
               rotation.z = originalRotation.z;
          }
          transform.rotation = Quaternion.Euler(rotation);
     }
}
