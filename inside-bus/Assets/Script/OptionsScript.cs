using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    [SerializeField] private GameObject _optionsMenuUI;
    [SerializeField] private PauseScript _pause;
    [SerializeField] private MenuScript _menu;

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
        if (this._pause != null)
        {
            if (this._pause.Flag == true)
            {
                this._optionsMenuUI.SetActive(false);
                this._pause.GetPauseMenuUI().SetActive(true);
                this._pause.Flag = false;
                Time.timeScale = 0f;
            }
        }

        else if(this._menu != null)
        {
            this._optionsMenuUI.SetActive(false);
            this._menu.FillUI();
            Time.timeScale = 1f;
        }
    }

}
