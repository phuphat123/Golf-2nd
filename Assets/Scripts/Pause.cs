using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] GameObject pauseMenu; //allows access outside of code
    
     void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       // if esc is pressed and game is paused it resumes game else pauses game
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isGamePaused)
            {
                ResumeGame();
                
            }
            else{
                PauseGame();

                
            }
        }
    }

    // Resumes game and unfreezes in game 
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused= false;
    }

    // Pauses game and freezes time in game 
    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused= true;
    }

    // Sets scene to 0 which is the main menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        

    }
   

    // Exits game 
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }



}
