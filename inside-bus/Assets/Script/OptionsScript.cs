using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private AudioManager _audioManager;

    // Start is called before the first frame update
    void Start()
    {
        this._musicSlider.value = PlayerPrefs.GetFloat("music", 0.75f);
        this._effectsSlider.value = PlayerPrefs.GetFloat("effects", 0.75f);
    }

    public void SetMusicVolume(float volume)
    {
        _audioManager.SetLevelMusic(volume);
    }

    public void SetEffectsVolume(float volume)
    {
        _audioManager.SetLevelEffects(volume);
    }

}
