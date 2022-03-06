using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenuUI;
    private int currentSceneIndex;
    public static bool GameIsPaused = false;
    public bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        GameIsPaused = true;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }

    public void goToOptionsMenu()
    {
        flag = true;
        PauseMenuUI.SetActive(false);
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene("Options Scene");
        Time.timeScale = 0f;

    }

    public void goToPause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

}
