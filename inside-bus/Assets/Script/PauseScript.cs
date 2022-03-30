using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject OptionsMenuUI;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject time;
    [SerializeField] private GameObject timeShadow;
    [SerializeField] private GameObject x;
    [SerializeField] private GameObject xShadow;
    [SerializeField] private GameObject lives;
    [SerializeField] private GameObject livesShadow;
    [SerializeField] private GameObject timetext;
    [SerializeField] private GameObject timetextShadow;
    [SerializeField] private GameObject AreYouSureUI;

    [SerializeField] private AnswerScript answer;

    public bool GameIsPaused = false;
    public bool flag = false;

    public GameObject getPauseButton()
    {
        return this.pauseButton;
    }

    public GameObject getPauseMenuUI()
    {
        return this.PauseMenuUI;
    }

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
        answer.getLessButton().SetActive(true);
        answer.getMoreButton().SetActive(true);
        answer.getAnswerButton().SetActive(true);
        FillUI();
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
        GameIsPaused = true;
        answer.getLessButton().SetActive(false);
        answer.getMoreButton().SetActive(false);
        answer.getAnswerButton().SetActive(false);
        ClearUI();
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

    public void FillUI()
    {
        pauseButton.SetActive(true);
        time.SetActive(true);
        timeShadow.SetActive(true);
        timetext.SetActive(true);
        timetextShadow.SetActive(true);
        lives.SetActive(true);
        livesShadow.SetActive(true);
        x.SetActive(true);
        xShadow.SetActive(true);
    }

    public void ClearUI()
    {
        pauseButton.SetActive(false);
        time.SetActive(false);
        timeShadow.SetActive(false);
        timetext.SetActive(false);
        timetextShadow.SetActive(false);
        lives.SetActive(false);
        livesShadow.SetActive(false);
        x.SetActive(false);
        xShadow.SetActive(false);
    }

}
