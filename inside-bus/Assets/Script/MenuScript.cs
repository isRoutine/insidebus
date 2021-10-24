using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToOptionsMenu() 
    {
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
