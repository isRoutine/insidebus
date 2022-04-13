using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _optionsMenuUI;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _time;
    [SerializeField] private GameObject _x;
    [SerializeField] private GameObject _lives;
    [SerializeField] private GameObject _timeText;
    [SerializeField] private GameObject _areYouSureUI;

    [SerializeField] private AnswerScript _answer;

    public bool GameIsPaused = false;
    public bool Flag = false;

    public GameObject GetPauseButton()
    {
        return this._pauseButton;
    }

    public GameObject GetPauseMenuUI()
    {
        return this._pauseMenuUI;
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
        // this._pauseMenuUI.SetActive(false);
        // this._answer.GetLessButton().SetActive(true);
        // this._answer.GetMoreButton().SetActive(true);
        // this._answer.GetAnswerButton().SetActive(true);
        FillUI();
        GameIsPaused = false;
        Time.timeScale = 1f;

    }

    public void GoToOptionsMenu()
    {
        this.Flag = true;
        this._pauseMenuUI.SetActive(false);
        this._optionsMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void GoToPause()
    {
        GameIsPaused = true;
        // this._answer.GetLessButton().SetActive(false);
        // this._answer.GetMoreButton().SetActive(false);
        // this._answer.GetAnswerButton().SetActive(false);
        ClearUI();
        this._pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GoBack()
    {
        this._areYouSureUI.SetActive(false);
        this._pauseMenuUI.SetActive(true);
    }

    public void AreYouSure()
    {
        this._areYouSureUI.SetActive(true);
        this._pauseMenuUI.SetActive(false);
    }

    public void FillUI()
    {
        this._pauseButton.SetActive(true);
        this._time.SetActive(true);
        this._timeText.SetActive(true);
        this._lives.SetActive(true);
        this._x.SetActive(true);
    }

    public void ClearUI()
    {
        this._pauseButton.SetActive(false);
        this._time.SetActive(false);
        this._timeText.SetActive(false);
        this._lives.SetActive(false);
        this._x.SetActive(false);
    }

}
