using System;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _optionsMenuUI;
    [SerializeField] private GameObject _areYouSureUI;
    private GameObject[] _gameUIObjects;

    private bool _isPaused = false;

    public GameObject GetPauseMenuUI()
    {
        return this._pauseMenuUI;
    }

    public bool GetIsPaused()
    {
        return this._isPaused;
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResumeGame()
    {
        this._pauseMenuUI.SetActive(false);
        FillUI();
        _isPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;

    }

    public void GoToOptionsMenu()
    {
        this._pauseMenuUI.SetActive(false);
        this._optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void GoToPause()
    {
        _isPaused = true;
        ClearUI();
        this._pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void GoBack()
    {
        this._areYouSureUI.SetActive(false);
        this._pauseMenuUI.SetActive(true);
    }

    public void AreYouSure()
    {
        this._areYouSureUI.SetActive(true);
        this._pauseMenuUI.SetActive(false);
    }

    public void FillUI()
    {
        foreach (GameObject g in _gameUIObjects)
            g.SetActive(true);
    }

    public void ClearUI()
    {
        _gameUIObjects = GameObject.FindGameObjectsWithTag("gameUI");
        Array.Resize<GameObject>(ref _gameUIObjects, 8);
        _gameUIObjects.SetValue(GameObject.FindGameObjectWithTag("scoreUI"), 7);
        foreach (GameObject g in _gameUIObjects)
            g.SetActive(false);

    }

}
