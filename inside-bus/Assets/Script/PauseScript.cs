using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject pauseButton;
    public GameObject home;

    public AnswerScript answer;
    
    public static bool GameIsPaused = false;
    public bool flag = false;

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
        PauseMenuUI.SetActive(false);
        answer.lessButtonGO.SetActive(true);
        answer.moreButtonGO.SetActive(true);
        answer.answerButtonGO.SetActive(true);
        pauseButton.SetActive(true);
        home.SetActive(true);
        GameIsPaused = false;
        Time.timeScale = 1f;

    }

    public void goToOptionsMenu()
    {
        flag = true;
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void goToPause()
    {
        pauseButton.SetActive(false);
        home.SetActive(false);
        GameIsPaused = true;
        answer.lessButtonGO.SetActive(false);
        answer.moreButtonGO.SetActive(false);
        answer.answerButtonGO.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

}
