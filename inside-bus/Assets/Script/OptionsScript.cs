using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public GameObject OptionsMenuUI;
    public PauseScript pause;
    public MenuScript menu;

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
        if (pause != null)
        {
            if (pause.flag == true)
            {
                OptionsMenuUI.SetActive(false);
                pause.PauseMenuUI.SetActive(true);
                pause.flag = false;
                Time.timeScale = 0f;
            }
        }

        else if(menu != null)
        {
            OptionsMenuUI.SetActive(false);
            menu.FillUI();
            Time.timeScale = 1f;
        }
    }

}
