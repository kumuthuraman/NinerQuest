using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataHolding : MonoBehaviour
{
    public Image image;
    public string caption;
    public bool isTask1;
    public bool isTask2;

    public GameObject imageDisplay;
    public GameObject captionText;

    public Toggle myToggle1;
    public Toggle myToggle2;

    public void OnToggle1() {

        if(myToggle1.isOn){
            isTask1 = true;
            isTask2 = false;
            myToggle2.isOn = false;
        }
        else{
            isTask1 = false;
            isTask2 = true;
            myToggle2.isOn = true;
        }
    }
    public void OnToggle2() {
        if(myToggle2.isOn){
            isTask1 = false;
            isTask2 = true;
            myToggle1.isOn = false;
        }
        else{
            isTask1 = true;
            isTask2 = false;
            myToggle1.isOn = true;
        }
    }

    public void OnSubmit() {
        image = imageDisplay.GetComponent<Image>();
        caption = captionText.GetComponent<TMP_Text>().text;
    }
}
