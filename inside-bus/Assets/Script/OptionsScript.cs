using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    [SerializeField] private GameObject _optionsMenuUI;
    [SerializeField] private PauseScript _pause;
    [SerializeField] private MenuScript _menu;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        this._musicSlider.value = PlayerPrefs.GetFloat("music", 0.75f);
        this._effectsSlider.value = PlayerPrefs.GetFloat("effects", 0.75f);
    }

    public void SetMusicVolume(float volume)
    {
        audioManager.SetLevelMusic(volume);
    }

    public void SetEffectsVolume(float volume)
    {
        audioManager.SetLevelEffects(volume);
    }

    public void GoBack()
    {
        if (this._pause != null)
        {
            if (this._pause.GetIsPaused() == true)
            {
                this._optionsMenuUI.SetActive(false);
                this._pause.GetPauseMenuUI().SetActive(true);
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
