using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private int currentSceneIndex;
    [SerializeField] private GameObject OptionsMenuUI;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject ScoreboardMenuUI;
    [SerializeField] private GameObject scoreboardButton;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject titleShadow;

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
        ClearUI();
        OptionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void goToGameScene()
    {
        SceneManager.LoadScene("Game Scene");
        Time.timeScale = 1f;
    }

    public void goToLoginScene()
    {
        SceneManager.LoadScene("Login Scene");
        Time.timeScale = 1f;
    }

    public void goToRankingsPanel()
    {
        ClearUI();
        ScoreboardMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClearUI()
    {
        title.SetActive(false);
        titleShadow.SetActive(false);
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        scoreboardButton.SetActive(false);
    }

    public void FillUI()
    {
        optionsButton.SetActive(true);
        playButton.SetActive(true);
        scoreboardButton.SetActive(true);
        title.SetActive(true);
        titleShadow.SetActive(true);
    }

}