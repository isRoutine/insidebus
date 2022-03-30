using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    [SerializeField] private GameObject OptionsMenuUI;
    [SerializeField] private PauseScript pause;
    [SerializeField] private MenuScript menu;

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
                pause.getPauseMenuUI().SetActive(true);
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
