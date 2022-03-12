using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardScript : MonoBehaviour
{
    public MenuScript menu;
    public GameObject ScoreboardMenuUI;

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
        if (menu != null)
        {
            ScoreboardMenuUI.SetActive(false);
            menu.optionsButton.SetActive(true);
            menu.playButton.SetActive(true);
            menu.scoreboardButton.SetActive(true);
            menu.title.SetActive(true);
            menu.titleShadow.SetActive(true);
            Time.timeScale = 1f;
        }
    }
}
