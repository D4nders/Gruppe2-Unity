using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : Scene_Manager
{
    public static bool isPaused = false;
    public GameObject pauseMenuCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuCanvas.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f; // Pausing the game
    }

    public void QuitGame()
    {
        TogglePause();
        SwitchScene("MainMenu");
    }
}
