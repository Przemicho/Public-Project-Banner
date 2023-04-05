using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
     //public float healthMax;
     public float weaponDamage;
     public float weaponDamageDeviation;

     public int strength, coordination, painResistance, wisdom, intelligence, armor;
     public bool isPiercing;

     public CreatureHealthScript thisCreatureHealth;
     public CreaturePhysicalDamageScript thisCreaturePhisicalDamage;
     public CreatureAttributesScript thisCreatureAttributes;
     public CreatureMagicalDamageScript thisCreatureMagicalDamage;

     private void Start()
     {
          thisCreatureAttributes = new CreatureAttributesScript(strength, coordination, painResistance, wisdom, intelligence, armor, isPiercing);
          thisCreatureHealth = new CreatureHealthScript(thisCreatureAttributes.Strength, thisCreatureAttributes.PainResistance);
          thisCreaturePhisicalDamage = new CreaturePhysicalDamageScript();
          thisCreatureMagicalDamage = new CreatureMagicalDamageScript();

          Debug.Log("thisCreatureAttributes.Strength " + thisCreatureAttributes.Strength);
     }
     
     public CreatureScript()
     {

     }

     public void ChangeCreatureHealth(float amount, bool reduceHealth)
     {
          if (reduceHealth)
          {
               thisCreatureHealth.ReduceHealth(amount);
          }
          else
          {
               thisCreatureHealth.AddHealth(amount);
          }
          if (thisCreatureHealth.Health <= 0)
          {
               Debug.Log("creature " + this.name + " killed");

               //Before destroying this gameObject have to unsubscribe from event in TurnEvoker
               this.GetComponent<TargetingScript>().OnCreatureKilled();
               Destroy(gameObject);
          }
     }

     public void ChangeCreatureHealth(float amount)
     {
          thisCreatureHealth.ChangeHealth(amount);
          if (thisCreatureHealth.Health <= 0)
          {
               Debug.Log("creature " + this.name + " killed");

               //Before destroying this gameObject have to unsubscribe from event in TurnEvoker
               this.GetComponent<TargetingScript>().OnCreatureKilled();
               Destroy(gameObject);
          }
     }

     public int GetCreatureAttributeValue(string attributeName)
     {
          switch (attributeName)
          {
               case "S":
               case "Strength":
                    UnityEngine.Debug.Log("TestS " + strength);
                    break;
               case "C":
               case "Coordination":
                    UnityEngine.Debug.Log("TestC " + coordination);
                    break;
               case "P":
               case "PainResistance":
                    break;
               case "W":
               case "Wisdom":
                    break;
               case "I":
               case "Intelligence":
                    break;
               case "A":
               case "Armor":
                    break;

               default:
                    UnityEngine.Debug.Log("Something went wrong, no attribute found");
                    break;
          }
          return 0;
     }

     public void Test()
     {
          Debug.Log("test");
     }


}
