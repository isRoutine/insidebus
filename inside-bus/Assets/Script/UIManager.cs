using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _optionsMenuUI;
    [SerializeField] private GameObject _scoreboardMenuUI;
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _areYouSureUI;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _highScoreImage;
    [SerializeField] private PlayFabManager _playFabManager;

    [SerializeField] private Animator _transition;

    private GameObject[] _gameUIObjects;
    private GameObject[] _menuUIObjects;

    private bool _isPaused = false;
    private bool _onScoreboardPanel = false;
    private bool _inGame = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Coroutine for transition from one scene to another
    IEnumerator LoadScene(String scene)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(scene);
    }

    //MainMenuUI
    public void GoToMainMenu()
    {
        _inGame = false;
        AudioListener.pause = false;

        StartCoroutine(LoadScene("MainMenu Scene"));
        Time.timeScale = 1f;
    }

    public void GoToGameScene()
    {
        StartCoroutine(LoadScene("Game Scene"));
        _inGame = true;
        Time.timeScale = 1f;
    }

    public void GoToLoginScene()
    {
        SceneManager.LoadScene("Login Scene");
        Time.timeScale = 1f;
    }

    public void GoToRankingsPanel()
    {
        _onScoreboardPanel = true;
        ClearUI();
        _scoreboardMenuUI.SetActive(true);

        Time.timeScale = 0f;
    }

    //PauseMenuUI in game
    public void ResumeGame()
    {
        _pauseMenuUI.SetActive(false);
        FillUI();
        _isPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;

    }

    public void GoToPause()
    {
        _isPaused = true;
        _inGame = true;
        ClearUI();
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void KeepPlaying()
    {
        _areYouSureUI.SetActive(false);
        _pauseMenuUI.SetActive(true);
    }

    public void AreYouSure()
    {
        _areYouSureUI.SetActive(true);
        _pauseMenuUI.SetActive(false);
    }

    //General GoBack() method for OptionsMenuUI in Game or MainMenu and ScoreboardMenuUI in MainMenu
    public void GoBack()
    {
        if (_isPaused)
        {
            _optionsMenuUI.SetActive(false);
            _pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }

        else if (_onScoreboardPanel) {
            _onScoreboardPanel = false;
            this._scoreboardMenuUI.SetActive(false);
            FillUI();
            Time.timeScale = 1f;
        }
        
        else
        {
            _optionsMenuUI.SetActive(false);
            FillUI();
            Time.timeScale = 1f;
        }
    }

    //General GoToOptions() method for MainMenuUI and PauseMenuUI
    public void GoToOptions()
    {
        if (_isPaused)
        {
            _pauseMenuUI.SetActive(false);
            _optionsMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }

        else
        {
            ClearUI();
            _optionsMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    //General ClearUI() method in MainMenu and game
    public void ClearUI()
    {   
        if (_inGame)
        {
            _gameUIObjects = GameObject.FindGameObjectsWithTag("gameUI");
            Array.Resize<GameObject>(ref _gameUIObjects, 8);
            _gameUIObjects.SetValue(GameObject.FindGameObjectWithTag("scoreUI"), 7);
            foreach (GameObject g in _gameUIObjects)
                g.SetActive(false);
        }
        
        else
        {
            _menuUIObjects = GameObject.FindGameObjectsWithTag("menuUI");
            foreach (GameObject g in _menuUIObjects)
                g.SetActive(false);
        }

    }

    //General FillUI() method in MainMenu and game
    public void FillUI()
    {
        if(_inGame)
        {
            foreach (GameObject g in _gameUIObjects)
                g.SetActive(true);
        }

        else
        {
            foreach (GameObject g in _menuUIObjects)
                g.SetActive(true);
        }
    }

    //GameOverUI
    public void SetGameOverUIActive()
    {
        _inGame = true;
        _gameOverUI.SetActive(true);
    }

    public bool IsGameOver()
    {
        return _gameOverUI.activeSelf;
    }

    public void SetHighScoreActive()
    {
        _highScoreImage.SetActive(true);
    }
}
