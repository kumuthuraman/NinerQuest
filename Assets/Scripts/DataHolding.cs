using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DataHolding : MonoBehaviour
{
    public Sprite sprite;
    public string caption;
    public bool isTask1;
    public bool isTask2;

    public GameObject imageDisplay;
    public GameObject captionText;

    public Toggle myToggle1;
    public Toggle myToggle2;

    public void OnToggle1() {
        isTask1 = true;
        isTask2 = false;
    }
    public void OnToggle2() {
        isTask1 = false;
        isTask2 = true;
    }

    public void OnSubmit() {
        sprite = imageDisplay.GetComponent<Image>().sprite;
        caption = captionText.GetComponent<TMP_InputField>().text;

        SceneManager.LoadScene("Feed");
    }
}
