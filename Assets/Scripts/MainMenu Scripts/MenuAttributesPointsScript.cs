using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuAttributesPointsScript : MonoBehaviour
{
     public int maxPointsAmount;
     public int remainingPoints { get; private set; }
     public TextMeshProUGUI attributesAmountDisplay;

    // Start is called before the first frame update
    void Start()
    {
          remainingPoints = maxPointsAmount;
          UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void ReduceRemainingPoints()
     {
          if (remainingPoints>0)
          {
               remainingPoints--;
               UpdateDisplay();
          }
     }

     public void ReduceRemainingPoints(int value)
     {
          if (remainingPoints>value)
          {
               remainingPoints -= value;
               UpdateDisplay();
          }
     }

     public void IncreaseRemainingPoints()
     {
          remainingPoints++;
          UpdateDisplay();
     }

     public void IncreaseRemainingPoints(int value)
     {
          remainingPoints += value;
          UpdateDisplay();
     }



     private void UpdateDisplay()
     {
          attributesAmountDisplay.SetText("Remaining points: " + remainingPoints);
     }
}
