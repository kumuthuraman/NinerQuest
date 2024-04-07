using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NavigationLogic : MonoBehaviour
{
    private Scene currScene;
    public GameObject saveBox;
    private string goTo;
    void Start() {
        currScene = SceneManager.GetActiveScene();
    }

    public void AskToSave(string goingTo) {
        goTo = goingTo;
        saveBox.SetActive(true);
    }

    public void CancelAskToSave() {
        saveBox.SetActive(false);
    }

    public void DoNav() {
        saveBox.SetActive(false);
        
        switch (goTo) {
            case "TaskList":
                GoTasks();
                break;
            case "Feed":
                GoFeed();
                break;
            case "Camera":
                GoCamera();
                break;
            case "Calendar":
                GoCalendar();
                break;
            case "Profile":
                GoProfile();
                break;
            default:
                throw new Exception("bad navigation input");
        }
    }
    public void GoTasks() {
        if (currScene.name != "TaskList") {
            Debug.Log("tasks");
            SceneManager.LoadScene("TaskList");
        }
    }
    public void GoFeed() {
        if (currScene.name != "Feed") {
            Debug.Log("feed");
            SceneManager.LoadScene("Feed");
        }
    }
    public void GoCamera() {
        if (currScene.name != "Camera") {
            Debug.Log("camera");
            SceneManager.LoadScene("Camera");
        }
    }
    public void GoCalendar() {
        if (currScene.name != "Calendar") {
            Debug.Log("camera");
            SceneManager.LoadScene("Calendar");
        }
    }
    public void GoProfile() {
        if (currScene.name != "Profile") {
            Debug.Log("camera");
            SceneManager.LoadScene("Profile");
        }
    }
}
