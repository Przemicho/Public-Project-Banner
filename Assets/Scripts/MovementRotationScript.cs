using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRotationScript : MonoBehaviour
{
     public SpriteRenderer spriteRenderer;
     public GameObject parent;

     private ProjectileArrowScript projectileArrow;
     private Vector3 nextPos;

     private void Start()
     {
          projectileArrow = parent.GetComponentInParent<ProjectileArrowScript>();
          nextPos = projectileArrow.nextPos;
     }
     public MovementRotationScript(bool flipX)
     {
          this.spriteRenderer.flipX = true;
     }

    void Update()
    {
          transform.LookAt(nextPos);
          transform.rotation *= Quaternion.Euler(180, 1, 1);
    }
}
