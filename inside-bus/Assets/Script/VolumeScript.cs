using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{

    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        this._musicSlider.value = PlayerPrefs.GetFloat("music", 0.75f);
        this._effectsSlider.value = PlayerPrefs.GetFloat("effects", 0.75f);
    }

    private void Awake()
    {
        DontDestroyOnLoad(instance);
        if (instance == null)
        {
            instance = this.instance;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
    }

    public void SetLevelMusic(float sliderValue)
    {
        this._mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("music", sliderValue);
    }

    public void SetLevelEffects(float sliderValue)
    {
        this._mixer.SetFloat("EffectsVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("effects", sliderValue);
    }
}
