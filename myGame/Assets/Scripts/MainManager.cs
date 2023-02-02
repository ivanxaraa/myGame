using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{



    public GameObject DeadScreen1;
    public GameObject DeadScreen2;
    public PlayerMovement movement1;
    public PlayerMovement movement2;
    public NaveScript NaveScript;

    public GameObject DeadEffect;

    public CharacterController2D controller1;
    public CharacterController2D controller2;

    public GameObject controlsMenu1;
    public GameObject controlsMenu2;

    public GameObject pressH1;
    public GameObject pressH2;

    bool gameHasEnded;
    private float DeadScreenDelay = 0.5f;

    private bool menuControlAtivado;

    public static bool GamePaused = false;

    public GameObject pauseMenuUI1;
    public GameObject pauseMenuUI2;


    [Header("Cheats")]
    public int health = 0;
    public int maxHealth = 100;

    private void Start()
    {
        pressH1.SetActive(true);
        pressH2.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if(menuControlAtivado == true)
            {
                controlsMenu1.SetActive(false);
                controlsMenu2.SetActive(false);
                menuControlAtivado = false;
            }
            else
            {
                pressH1.SetActive(false);
                pressH2.SetActive(false);
                controlsMenu1.SetActive(true);
                controlsMenu2.SetActive(true);
                menuControlAtivado = true;
            }
            
        }

        //cheats

        if (Input.GetKey(KeyCode.F))
        {
            
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                
                Pause();
            }
        }
    }


    public void endGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            movement1.enabled = false;
            movement2.enabled = false;
            NaveScript.enabled = false;

            //effect            
            Destroy(movement1.gameObject);
            Destroy(movement2.gameObject);
            Instantiate(DeadEffect, movement1.transform.position, Quaternion.identity);
            Instantiate(DeadEffect, movement2.transform.position, Quaternion.identity);
            Invoke("DeadScreen", DeadScreenDelay);            
        }        
    }

    void DeadScreen()
    {
        DeadScreen1.SetActive(true);
        DeadScreen2.SetActive(true);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void closeControlsMenu()
    {
        controlsMenu1.SetActive(false);
        controlsMenu2.SetActive(false);
    }



    public void Resume()
    {
        pauseMenuUI1.SetActive(false);
        pauseMenuUI2.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        
        
    }


    void Pause()
    {
        pauseMenuUI1.SetActive(true);
        pauseMenuUI2.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        
        
    }




    public void QuitGame()
    {
        Application.Quit();
    }



    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");



    }
}
