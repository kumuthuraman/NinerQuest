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
