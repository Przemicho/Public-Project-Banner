using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreaturePersistanceAttributesScript : MonoBehaviour
{
     public static Dictionary<string, int> attributesValuesAttackerPairs = new Dictionary<string, int>();
     public static Dictionary<string, int> attributesValuesDefenderPairs = new Dictionary<string, int>();

     /*private void Awake()
     {
          attributesValuesPairs.Add("sA", 0);
          attributesValuesPairs.Add("cA", 0);
          attributesValuesPairs.Add("pA", 0);
          attributesValuesPairs.Add("wA", 0);
          attributesValuesPairs.Add("iA", 0);

          attributesValuesPairs.Add("sD", 0);
          attributesValuesPairs.Add("cD", 0);
          attributesValuesPairs.Add("pD", 0);
          attributesValuesPairs.Add("wD", 0);
          attributesValuesPairs.Add("iD", 0);
     }




     /*private void Awake()
     {
          DontDestroyOnLoad(this.gameObject);
     }*/



}
