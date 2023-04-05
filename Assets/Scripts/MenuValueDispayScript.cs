using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuValueDispayScript : MonoBehaviour
{

     public Slider slider;
     public TextMeshProUGUI thisText;
    // Start is called before the first frame update
    void Start()
    {
          slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
          thisText.SetText(slider.value.ToString());
    }

     public void ValueChangeCheck()
     {
          thisText.SetText(slider.value.ToString());
     }
}
