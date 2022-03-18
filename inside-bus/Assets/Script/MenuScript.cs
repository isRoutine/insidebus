using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private int currentSceneIndex;
    public GameObject OptionsMenuUI;
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject ScoreboardMenuUI;
    public GameObject scoreboardButton;
    public GameObject title;
    public GameObject titleShadow;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu Scene");
        Time.timeScale = 1f;
    }

    public void goToOptionsMenu()
    {
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        OptionsMenuUI.SetActive(true);
        scoreboardButton.SetActive(false);
        title.SetActive(false);
        titleShadow.SetActive(false);
        Time.timeScale = 0f;
    }

    public void goToGameScene()
    {
        SceneManager.LoadScene("Game Scene");
        Time.timeScale = 1f;
    }

    public void goToRankingsPanel()
    {
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        scoreboardButton.SetActive(false);
        ScoreboardMenuUI.SetActive(true);
        title.SetActive(false);
        titleShadow.SetActive(false);
        Time.timeScale = 0f;
    }

}