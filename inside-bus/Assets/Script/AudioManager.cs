using UnityEngine;
using UnityEngine.Audio;
using System;

[System.Serializable]
public class Sound
{
    public AudioClip clip;

    public string name;

    [Range(0.0001f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;

    public AudioMixerGroup output;
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    [SerializeField] private AudioMixer _musicMixer;
    [SerializeField] private AudioMixer _effectsMixer;

    // Start is called before the first frame update
    private void Start()
    {
        Play("Theme");
    }

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.output;
        }

        UpdateMixer();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!\n");
            return; 
        }
        
        s.source.Play();
    }

    public void SetLevelMusic(float sliderValue)
    {
        _musicMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("music", sliderValue);
    }

    public void SetLevelEffects(float sliderValue)
    {
        _effectsMixer.SetFloat("EffectsVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("effects", sliderValue);
    }

    public void UpdateMixer()
    {
        _musicMixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("music") * 20));
        _effectsMixer.SetFloat("EffectsVol", Mathf.Log10(PlayerPrefs.GetFloat("effects") * 20));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
