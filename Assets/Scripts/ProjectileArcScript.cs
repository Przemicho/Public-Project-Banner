using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArcScript : MonoBehaviour
{
     public float velocity;
     public float angle;

     private float gravity;
     private float radianAngle;
     private float maxDistance;



     private void Awake()
     {
          gravity = Mathf.Abs(Physics.gravity.y);
          radianAngle = Mathf.Rad2Deg * angle;
          maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / gravity;
     }

     private void Start()
     {
          
     }

}
