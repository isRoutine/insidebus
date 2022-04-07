using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private int _currentSceneIndex;
    [SerializeField] private GameObject _optionsMenuUI;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _optionsButton;
    [SerializeField] private GameObject _scoreboardMenuUI;
    [SerializeField] private GameObject _scoreboardButton;
    [SerializeField] private GameObject _title;

    // Start is called before the first frame update
    void Start()
    {
        this._currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu Scene");
        Time.timeScale = 1f;
    }

    public void GoToOptionsMenu()
    {
        ClearUI();
        this._optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game Scene");
        Time.timeScale = 1f;
    }

    public void GoToLoginScene()
    {
        SceneManager.LoadScene("Login Scene");
        Time.timeScale = 1f;
    }

    public void GoToRankingsPanel()
    {
        ClearUI();
        this._scoreboardMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClearUI()
    {
        this._title.SetActive(false);
        this._playButton.SetActive(false);
        this._optionsButton.SetActive(false);
        this._scoreboardButton.SetActive(false);
    }

    public void FillUI()
    {
        this._optionsButton.SetActive(true);
        this._playButton.SetActive(true);
        this._scoreboardButton.SetActive(true);
        this._title.SetActive(true);
    }

}