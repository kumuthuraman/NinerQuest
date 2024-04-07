using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Profile : MonoBehaviour
{
    public TMP_Text userName;
    public TMP_Text name;
    public TMP_Text email;

    public TMP_Text streaks;


    // Start is called before the first frame update
    void Start()
    {
        name.text  = PlayerPrefs.GetString("userId");
        email.text  = PlayerPrefs.GetString("email");
        userName.text  = PlayerPrefs.GetString("displayName");
        streaks.text = PlayerPrefs.GetInt("streak").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
