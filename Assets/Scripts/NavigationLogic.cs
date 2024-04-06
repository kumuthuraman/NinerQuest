using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationLogic : MonoBehaviour
{
    private Scene currScene;
    void Start() {
        currScene = SceneManager.GetActiveScene();
    }
    public void GoTasks() {
        if (currScene.name != "Tasks") {
            SceneManager.LoadScene("Tasks");
        }
    }
    public void GoFeed() {
        if (currScene.name != "Feed") {
            SceneManager.LoadScene("Feed");
        }
    }
    public void GoCamera() {
        if (currScene.name != "Camera") {
            SceneManager.LoadScene("Camera");
        }
    }
    public void GoCalendar() {
        if (currScene.name != "Calendar") {
            SceneManager.LoadScene("Calendar");
        }
    }
    public void GoProfile() {
        if (currScene.name != "Profile") {
            SceneManager.LoadScene("Profile");
        }
    }
}
