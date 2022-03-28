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
            menu.FillUI();
            Time.timeScale = 1f;
        }
    }
}
