using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music", 0.75f);
        effectsSlider.value = PlayerPrefs.GetFloat("effects", 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetLevelMusic(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("music", sliderValue);
    }

    public void SetLevelEffects(float sliderValue)
    {
        mixer.SetFloat("EffectsVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("effects", sliderValue);
    }
}
