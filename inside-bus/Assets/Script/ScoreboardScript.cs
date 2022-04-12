using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardScript : MonoBehaviour
{
    [SerializeField] private MenuScript _menu;
    [SerializeField] private GameObject _scoreboardMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBack()
    {
        if (this._menu != null)
        {
            this._scoreboardMenuUI.SetActive(false);
            this._menu.FillUI();
            Time.timeScale = 1f;
        }
    }
}
