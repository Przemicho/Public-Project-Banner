using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrowScript : MonoBehaviour
{
     private Vector3 enemyLocation;
     private Vector3 startLocation;

     private string enemyTag;
     private string thisSpawnerTag;

     private float arcHeight = 1;
     private float distance;
     private float adjustedVelocity;
     private float timeToTarget = 1f;

     public Vector3 nextPos;

     private float thisDamage;

     private MovementRotationScript movementRotationScript;
     //private CreatureScript creatureScript;
     private void Start()
     {
          transform.LookAt(enemyLocation);

          distance = Vector3.Distance(enemyLocation, startLocation);
          arcHeight = timeToTarget / distance * distance;
          adjustedVelocity = distance / timeToTarget;
     }

     private void Update()
     {
          //calculation made to projectile fly in a arc
          float x0 = startLocation.x;
          float x1 = enemyLocation.x;
          float z0 = startLocation.z;
          float z1 = enemyLocation.z;
          float distanceZ = z1 - z0;
          float distance = x1 - x0;
          float nextX = Mathf.MoveTowards(transform.position.x, x1, adjustedVelocity * Time.deltaTime);
          float nextZ = Mathf.MoveTowards(transform.position.z, z1, adjustedVelocity * Time.deltaTime);
          float baseY = Mathf.Lerp(startLocation.y, enemyLocation.y, (nextX - x0) / distance);
          float baseZ = Mathf.Lerp(startLocation.z, enemyLocation.z, (nextX - x0) / distance);
          float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * distance * distance);
          nextPos = new Vector3(nextX, baseY + arc, baseZ);
          transform.LookAt(nextPos);
          transform.position = nextPos;

          //projectile is destroied after reaching target
          if (nextPos==enemyLocation)
          {
               Destroy(gameObject);
          }

     }

     //listeners for TergetingScript this projectile instantiation sendMessage functions
     public void Target( Transform target)
     {
          enemyLocation = target.position;
     }

     public void ProjectileSpawnPosition( Transform spawn)
     {
          startLocation = spawn.position;
     }

     public void EnemyTag(string enemyTag)
     {
          this.enemyTag = enemyTag;
     }
     
     public void ThisSpawnerTag(string thisSpawnerTag)
     {
          this.thisSpawnerTag = thisSpawnerTag;
     }

     public void ProjectileSpeed(float timeToTarget)
     {
          this.timeToTarget = timeToTarget;
     }

     //Calls when projectile hit collider with trigger
     private void OnTriggerEnter(Collider other)
     {
          //checking if projectile reached enemy or setting damage of projectile when leaving instantiating object
          if (other.tag == thisSpawnerTag)
          {
               CreatureScript creatureScript = other.gameObject.GetComponent<CreatureScript>();
               thisDamage = creatureScript.thisCreaturePhisicalDamage.GetFinalDamageAmount
                    (
                    creatureScript.thisCreatureAttributes.Strength,
                    creatureScript.thisCreatureAttributes.Coordination,
                    creatureScript.thisCreatureAttributes.Armor,
                    creatureScript.thisCreatureAttributes.Intelligence
                    ) * -1;//<if used without delaring if damage or heal it's necessary to multiply by -1 to deal damage
          }
          if (other.tag == enemyTag)
          {
               GameObject targetObject = other.gameObject;
               //targetObject.GetComponent<CreatureScript>().ChangeCreatureHealth(thisDamage - thisDamage * other.gameObject.GetComponent<CreatureScript>().thisCreatureAttributes.Armor, true);
               targetObject.GetComponent<CreatureScript>().ChangeCreatureHealth(thisDamage - thisDamage * other.gameObject.GetComponent<CreatureScript>().thisCreatureAttributes.Armor);
               //other.
          }
     }

     
}
