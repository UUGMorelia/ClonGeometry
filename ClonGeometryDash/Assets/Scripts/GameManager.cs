using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isPaused = false;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("GM is null");
            }
            return instance;
        }
    }

    public Text diamondsTxt;
    public Text totalDiamonds;

    /* 
     *  0 => Pause
     *  1 => Main menu
     *  2 => Game over
     *  3 => score
     *  4 => Btn Pause 
     */
    public GameObject[] uiElements;

	// Use this for initialization
	void Awake ()
    {
        instance = this;

        isPaused = true;
        Time.timeScale = 0;
        uiElements[1].SetActive(true);
        uiElements[3].SetActive(false);
        uiElements[4].SetActive(false);
    }
	
	public void PauseGame()
    {
        if(!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            uiElements[0].SetActive(true);
            uiElements[3].SetActive(false);
            uiElements[4].SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            uiElements[0].SetActive(false);
            uiElements[3].SetActive(true);
            uiElements[4].SetActive(true);
        }
    }

    public void GameOverUI()
    {
        //Show Game over UI
        Time.timeScale = 0;
        uiElements[2].SetActive(true);
        uiElements[3].SetActive(false);
        uiElements[4].SetActive(false);
    }

    public void UpdateCurrentDiamonds(int diamonds)
    {
        diamondsTxt.text = "" + diamonds;
        totalDiamonds.text = "" + diamonds;
    }

    public void MainMenu()
    {
        //Show main menu
        Time.timeScale = 0;
        uiElements[1].SetActive(true);
        uiElements[3].SetActive(false);
        uiElements[4].SetActive(false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayNewGame()
    {
        uiElements[1].SetActive(false);
        PauseGame();
    }
}
