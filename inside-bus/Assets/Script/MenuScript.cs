using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private int currentSceneIndex;

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
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene("Options Scene");
        Time.timeScale = 1f;
    }

    public void goToGameScene()
    {
        SceneManager.LoadScene("Game Scene");
        Time.timeScale = 1f;
    }

    public void goToRankingsScene()
    {
        SceneManager.LoadScene("Rankings Scene");
        Time.timeScale = 1f;
    }

}