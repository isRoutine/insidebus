using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private int _currentSceneIndex;
    [SerializeField] private GameObject _optionsMenuUI;
    [SerializeField] private GameObject[] _menuUIObjects;
    [SerializeField] private GameObject _scoreboardMenuUI;

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
        AudioListener.pause = false;
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
        _menuUIObjects = GameObject.FindGameObjectsWithTag("menuUI");
        foreach (GameObject g in _menuUIObjects)
            g.SetActive(false);
    }

    public void FillUI()
    {
        foreach (GameObject g in _menuUIObjects)
            g.SetActive(true);
    }

}