using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class nextMonth : MonoBehaviour
{
    public TMP_Text monthName;
    
    public void goToNextMonth() {
        monthName.text = "May";
    }
}
