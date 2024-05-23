using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : Scene_Manager
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
}