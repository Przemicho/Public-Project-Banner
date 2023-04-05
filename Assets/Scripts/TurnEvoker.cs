using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEvoker : MonoBehaviour
{
     private bool sideChecker = true;
     
     //TODO change bool function in event to enum
     public enum Side
     {
          Attacker,
          Deffender
     }
     public event EventHandler<OnTurnStartEventArgs> OnTurnStart;

     public class OnTurnStartEventArgs : EventArgs
     {
          public bool sideChecker;
     }


    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Space))
          {
               if (OnTurnStart != null)
               {
                    OnTurnStart(this, new OnTurnStartEventArgs { sideChecker = sideChecker } );
               }
               sideChecker = !sideChecker;
          }
        
    }
}
