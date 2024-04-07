using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class getPrevMonth : MonoBehaviour
{
    public TMP_Text monthName;

    public void prevMonth() {
        monthName.text = "March";
    }

}
