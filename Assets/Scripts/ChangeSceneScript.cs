using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneScript : MonoBehaviour
{
     public Slider sliderAttacker;
     public Slider sliderDefender;

     public void LoadScene(string sceneName)
     {
          PlayerPrefs.SetFloat("attackerAmount", sliderAttacker.value);
          PlayerPrefs.SetFloat("defenderAmount", sliderDefender.value);

          SceneManager.LoadScene(sceneName);
     }
}
