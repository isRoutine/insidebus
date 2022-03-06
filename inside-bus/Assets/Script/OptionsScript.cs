using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{
    private int prevScene;
    public PauseScript pause;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void goBack()
    {
        prevScene = PlayerPrefs.GetInt("SavedScene");
        if (pause.flag == true)
        {
            SceneManager.LoadScene(prevScene);
            pause.PauseMenuUI.SetActive(true);
            pause.flag = false;
            Time.timeScale = 1f;
        }
        else
        {
            if (prevScene >= 0)
            {
                SceneManager.LoadScene(prevScene);
                Time.timeScale = 1f;
            }
            else
                return;
        }
    }

}
