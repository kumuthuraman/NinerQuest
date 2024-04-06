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

    public void OnToggle1() {

    }

    public void OnSubmit() {
        image = imageDisplay.GetComponent<Image>();
        caption = captionText.GetComponent<TMP_Text>().text;
    }
}
