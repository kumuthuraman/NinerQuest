using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PicturePopUp : MonoBehaviour
{
    public GameObject popUpPanelBorder;
    void Start() {
        /*
        popUpPanelBorder = GameObject.FindGameObjectsWithTag("GrabMe")[0];
        */
    }
    public void PopUp() {
        Image dayImage = gameObject.GetComponent<Image>();
        GameObject dayNum = gameObject.transform.GetChild(0).GetChild(1).gameObject;

        GameObject popUpImage = popUpPanelBorder.transform.GetChild(0).GetChild(0).gameObject;
        GameObject popUpText = popUpPanelBorder.transform.GetChild(0).GetChild(1).gameObject;

        popUpImage.GetComponent<Image>().sprite = dayImage.sprite;
        popUpText.GetComponent<TMP_Text>().text = dayNum.GetComponent<TMP_Text>().text;

        popUpPanelBorder.SetActive(true);
    }

    public void PopDown() {
        gameObject.SetActive(false);
    }
}
