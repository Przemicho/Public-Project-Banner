using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationScript : MonoBehaviour
{

     public Transform target;
     public float timeToTarget;

     private float speed;
     private Vector3 startPosition;
     private Vector3 actualTarget;

    // Start is called before the first frame update
    void Start()
    {
          startPosition = transform.position;
          actualTarget = startPosition;
          speed = Vector3.Distance(startPosition, target.position)/timeToTarget;
    }

    // Update is called once per frame
    void Update()
    {
          var step = speed * Time.deltaTime;
          transform.position = Vector3.MoveTowards(transform.position, actualTarget, step);
    }

     public void OnButtonClick()
     {
          //actualSpeed = speed;
          if (gameObject.transform.position==target.position)
          {
               actualTarget = startPosition;
          }
          else
          {
               actualTarget = target.position;
          }
     }
}
