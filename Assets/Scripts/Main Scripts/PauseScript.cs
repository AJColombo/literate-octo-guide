using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private AudioSource AudioPlayer;
    // Update is called once per frame
    void Update()
    {
        //|| Input.GetButtonDown("Pause")
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused)
            { 
                Resume();
            } else {
                Pause();
            }
        }

    }

    public void Resume () {
        pauseMenuUI.SetActive(false);
        Time.timeScale =1f;
        GameIsPaused = false;
        AudioPlayer = GameObject.Find("Music").GetComponent<AudioSource>();
        AudioPlayer.mute = false;
    }
    private void Pause () {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioPlayer = GameObject.Find("Music").GetComponent<AudioSource>();
        AudioPlayer.mute = true;
    }

    public void LoadMenu() {
        //Resume();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }
    

    
    public void QuitGame() {
        Application.Quit();
    }
}
