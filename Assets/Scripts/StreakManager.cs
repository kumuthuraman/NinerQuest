using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StreakManager : MonoBehaviour
{
    public TMP_Text streaks;
    // public TextMeshPro streaks;

    // Start is called before the first frame update
    void Start()
    {
        // TextMeshPro streaks = streaksGameObject.GetComponent<TextMeshPro>();
        streaks.text = PlayerPrefs.GetInt("streak").ToString();
    }
}
