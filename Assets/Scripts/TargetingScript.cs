using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingScript : MonoBehaviour
{
     //private Vector3 projectileSpawnPosition;
     private Transform target;
     private Transform projectileSpawnPosition;
     private GameObject battleHandler;
     private string enemyTag;
     
     public GameObject projectile;

     public float projectileSpeed;

     private void Awake()
     {
          //Reference to BattleHandler object in world
          battleHandler = GameObject.Find("BattleHandler");

          //Reference to ProjectileSpawnLocation object position in world
          projectileSpawnPosition = transform.Find("ProjectileSpawnLocation");
     }

     private void Start()
     {
          //Custom method to update target every half a second not every frame
          //InvokeRepeating("UpdateTarget", 0f, 0.5f

          if (this.tag == "Attacker")
          {
               enemyTag = "Defender";
          }
          else
          {
               enemyTag = "Attacker";
          }

          UpdateTarget();

          //Subscription to TurnEvoker event in BattleHandler object
          battleHandler.GetComponent<TurnEvoker>().OnTurnStart += TurnEvoker_OnTurnStart;
     }

     private void TurnEvoker_OnTurnStart(object sender, TurnEvoker.OnTurnStartEventArgs e)
     {
          UpdateTarget();
          PerformAnAttack(e.sideChecker);
     }

     private void PerformAnAttack(bool sideDependancy)
     {
          //Debug.Log("side " + sideDependancy);
          if (sideDependancy && this.tag == "Attacker")
          {
               //Debug.Log("Attack action was performed by " + this.name);
               InstantiateProjectile();

          }
          else if (!sideDependancy && this.tag == "Defender")
          {
               //Debug.Log("Attack action was performed by " + this.name);
               InstantiateProjectile();
          }
     }

     private void UpdateTarget()
     {
          GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
          if (enemies.Length!=0)
          {
               foreach (GameObject item in enemies)
               {
                    //Debug.Log(this.name + " found " + item+ " enemy on " + item.transform.position + " position");
               }
               target = enemies[Random.Range(0, enemies.Length)].transform;
          }
          //Debug.Log("enemies = " + enemies.Length);
     }

     private void InstantiateProjectile()
     {
          GameObject gameObject = Instantiate(projectile, projectileSpawnPosition.position, projectileSpawnPosition.rotation);
          gameObject.SendMessage("Target", target);
          gameObject.SendMessage("ProjectileSpawnPosition", projectileSpawnPosition);
          gameObject.SendMessage("EnemyTag", enemyTag);
          gameObject.SendMessage("ThisSpawnerTag", this.tag);
          gameObject.SendMessage("ProjectileSpeed", projectileSpeed);
     }

     public void OnCreatureKilled()
     {

          battleHandler.GetComponent<TurnEvoker>().OnTurnStart -= TurnEvoker_OnTurnStart;
     }

}
