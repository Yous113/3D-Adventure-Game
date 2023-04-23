using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [Header("UI")]
    public GameObject pauseMenu;
    public GameObject mainUI;
    private bool isPaused = false;

    // Update is called once per frame
    public void OnPause(InputAction.CallbackContext context)
    {
        if(!isPaused)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        print("Paused");
        pauseMenu.SetActive(true);
        mainUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnPauseGame() 
    {

        pauseMenu.SetActive(false);
        mainUI.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
