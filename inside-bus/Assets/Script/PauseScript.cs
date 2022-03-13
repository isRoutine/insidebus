using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject pauseButton;
    public GameObject time;
    public GameObject timeShadow;
    public GameObject x;
    public GameObject xShadow;
    public GameObject lives;
    public GameObject livesShadow;
    public GameObject timetext;
    public GameObject timetextShadow;
    public GameObject AreYouSureUI;

    public AnswerScript answer;

    public bool GameIsPaused = false;
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
        time.SetActive(true);
        timeShadow.SetActive(true);
        x.SetActive(true);
        xShadow.SetActive(true);
        lives.SetActive(true);
        livesShadow.SetActive(true);
        timetext.SetActive(true);
        timetextShadow.SetActive(true);
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
        GameIsPaused = true;
        answer.lessButtonGO.SetActive(false);
        answer.moreButtonGO.SetActive(false);
        answer.answerButtonGO.SetActive(false);
        time.SetActive(false);
        timeShadow.SetActive(false);
        x.SetActive(false);
        xShadow.SetActive(false);
        lives.SetActive(false);
        livesShadow.SetActive(false);
        timetext.SetActive(false);
        timetextShadow.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void goBack()
    {
        AreYouSureUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void AreYouSure()
    {
        AreYouSureUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }

}
