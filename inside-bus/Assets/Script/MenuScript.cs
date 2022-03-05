using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public void goToOptionsMenu() 
    {
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene("Options Scene");
    }

    public void goToGameScene()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void goToRankingsScene()
    {
        SceneManager.LoadScene("Rankings Scene");
    }

}
