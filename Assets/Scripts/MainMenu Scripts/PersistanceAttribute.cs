using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PersistanceAttribute : MonoBehaviour
{
     public Slider slider;
     public TextMeshProUGUI amountText;//rework this to value textbox get this value on change, to remove this
     public int minValue, maxValue;//curently redundant as min and max values can be extrapolated from slider min and max
     public GameObject pointHolder;//rework this to value textbox get this value on change, to remove this
     public bool isAttacker;

     public int attributeValue { get; private set; }

private void Start()
     {
          attributeValue = (int)slider.value;
          amountText.SetText(attributeValue.ToString());
          SaveAttribute();
     }

     public void AddAttributeValue()
     {
          if (pointHolder.GetComponent<MenuAttributesPointsScript>().remainingPoints > 0)
          {
               slider.value++;
          }
     }

     public void RemoveAttributeValue()
     {
          slider.value --;
     }

     public void ChangeAttributeValue()
     {
          if (pointHolder.GetComponent<MenuAttributesPointsScript>().remainingPoints>=0)
          {
               //Slider is moved to left(value decreases)
               if (int.Parse(amountText.text)>slider.value)
               {
                    pointHolder.GetComponent<MenuAttributesPointsScript>().IncreaseRemainingPoints();
                    attributeValue = (int)slider.value;
               }
               //Slider is moved to right(value increases)
               else
               {
                    pointHolder.GetComponent<MenuAttributesPointsScript>().ReduceRemainingPoints();
                    attributeValue = (int)slider.value;
               }
               attributeValue = Mathf.Clamp(attributeValue, minValue, maxValue);
               amountText.SetText(attributeValue.ToString());
               SaveAttribute();
          }
     }

     public void SaveAttribute()
     {
          if (isAttacker)
          {
               try
               {
                    CreaturePersistanceAttributesScript.attributesValuesAttackerPairs.Add(this.gameObject.name, attributeValue);
               }
               catch (System.Exception)
               {
                    CreaturePersistanceAttributesScript.attributesValuesAttackerPairs[this.gameObject.name] = attributeValue;
               }
          }
          else
          {
               try
               {
                    CreaturePersistanceAttributesScript.attributesValuesDefenderPairs.Add(this.gameObject.name, attributeValue);
               }
               catch (System.Exception)
               {
                    CreaturePersistanceAttributesScript.attributesValuesDefenderPairs[this.gameObject.name] = attributeValue;
               }
          }
          
     }
}
// suma wydanych punktów to maxPointsAmount - remainingPoints