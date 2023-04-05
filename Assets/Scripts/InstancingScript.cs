using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstancingScript : MonoBehaviour
{
     public Grid grid;

     public GameObject attacker;
     public GameObject defender;
          
    // Start is called before the first frame update
    void Awake()
    {
          spawner((int)PlayerPrefs.GetFloat("attackerAmount"), attacker, "Attacker", 0);
          spawner((int)PlayerPrefs.GetFloat("defenderAmount"), defender, "Defender", 10);
          
          /*Debug.Log("attackerAmount " + PlayerPrefs.GetFloat("attackerAmount"));
          
          if (Enumerable.Range(0, 100).Contains((int)PlayerPrefs.GetFloat("defenderAmount")))
          {
               for (int i = 0; i < (int)PlayerPrefs.GetFloat("defenderAmount"); i++)
               {
                    Instantiate(defender, new Vector3(10, 0, i*0.32f), Quaternion.identity);
                    defender.tag = "Defender";
               }
          }
          else
          {
               Debug.Log("defenderAmount was out of scope");
          }
          Debug.Log("defenderAmount " + PlayerPrefs.GetFloat("defenderAmount"));
          */
    }

     private void Start()
     {
          //attacker.GetComponent<CreatureScript>().thisCreatureAttributes.ManipulateAttribute("S", 10);
     }

     private void spawner(int spawnAmount, GameObject instancedObject, string tag, int xDisplacement)
     {
          if (Enumerable.Range(1, 101).Contains(spawnAmount))
          {
               int z = 0;
               for (int i = 0; i < spawnAmount; i++)
               {
                    z++;
                    if (i % 10 == 0)
                    {
                         xDisplacement++;
                         z = 0;
                    }
                    if (tag == "Defender")
                    {

                         GameObject instancedCreature = Instantiate(instancedObject, new Vector3(xDisplacement * 0.64f, 0, z * 0.64f), Quaternion.identity);
                         instancedCreature.GetComponent<CreatureScript>().strength = CreaturePersistanceAttributesScript.attributesValuesDefenderPairs["Strength"];
                         instancedCreature.GetComponent<CreatureScript>().coordination = CreaturePersistanceAttributesScript.attributesValuesDefenderPairs["Coordination"];
                         instancedCreature.GetComponent<CreatureScript>().painResistance = CreaturePersistanceAttributesScript.attributesValuesDefenderPairs["PainResistance"];
                         instancedCreature.GetComponent<CreatureScript>().wisdom = CreaturePersistanceAttributesScript.attributesValuesDefenderPairs["Wisdom"];
                         instancedCreature.GetComponent<CreatureScript>().intelligence = CreaturePersistanceAttributesScript.attributesValuesDefenderPairs["Intelligence"];
                         instancedCreature.GetComponent<CreatureScript>().armor = CreaturePersistanceAttributesScript.attributesValuesDefenderPairs["Armor"];
                    }
                    else
                    {
                         GameObject instancedCreature = Instantiate(instancedObject, new Vector3(-xDisplacement * 0.64f, 0, z * 0.64f), Quaternion.identity);
                         instancedCreature.GetComponent<CreatureScript>().strength = CreaturePersistanceAttributesScript.attributesValuesAttackerPairs["Strength"];
                         instancedCreature.GetComponent<CreatureScript>().coordination = CreaturePersistanceAttributesScript.attributesValuesAttackerPairs["Coordination"];
                         instancedCreature.GetComponent<CreatureScript>().painResistance = CreaturePersistanceAttributesScript.attributesValuesAttackerPairs["PainResistance"];
                         instancedCreature.GetComponent<CreatureScript>().wisdom = CreaturePersistanceAttributesScript.attributesValuesAttackerPairs["Wisdom"];
                         instancedCreature.GetComponent<CreatureScript>().intelligence = CreaturePersistanceAttributesScript.attributesValuesAttackerPairs["Intelligence"];
                         instancedCreature.GetComponent<CreatureScript>().armor = CreaturePersistanceAttributesScript.attributesValuesAttackerPairs["Armor"];
                    }
                    instancedObject.tag = tag;
               }
          }
          else
          {
               Debug.Log(tag + " amount was out of scope");
          }
     }




     /*foreach (var attribute in CreaturePersistanceAttributesScript.attributesValuesDefenderPairs)
     {
          instancedObject.GetComponent<CreatureScript>().thisCreatureAttributes.ManipulateAttribute(attribute.Key, attribute.Value);
     }*/
}
