using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    // Lists to hold all SFX and BG audio sources
    private List<AudioSource> sfxAudioSources = new List<AudioSource>();
    private List<AudioSource> bgAudioSources = new List<AudioSource>();
    // Audio source for SFX sounds
    private AudioSource sfxAudioSource;
   // Boolean variables to track mute status
    public bool sfxMuted = false;
    public bool bgMuted = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Load mute states from PlayerPrefs
        sfxMuted = PlayerPrefs.GetInt("SFXMuted", 0) == 1;
        bgMuted = PlayerPrefs.GetInt("BGSoundMuted", 0) == 1;

        // Create an audio source for SFX sounds
        sfxAudioSource = gameObject.AddComponent<AudioSource>();
    }

    //Sound Effects
    public AudioClip openDoor, marketDoorOpen, changeUniform, lightsFlicker, boxOpen, placeBox, mouseClick, doorKnocks, somethingOutside;
    //BackGround Music
    public AudioClip roomMusic, marketMusic, outsideMusic, storageroomMusic, hallapartmentMusic, die, menu;
    //Current Music Object
    public static GameObject currentMusicObject;
    //Sound Object
    public GameObject soundObject;
    public GameObject bgsoundObject;

    void Start()
    {
        // Get all audio sources in the scene and categorize them as SFX or BG
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.CompareTag("SFX"))
            {
                sfxAudioSources.Add(audioSource);
            }
            else if (audioSource.CompareTag("BG"))
            {
                bgAudioSources.Add(audioSource);
            }
        }

        // Apply mute state to BG audio sources
        foreach (AudioSource audioSource in bgAudioSources)
        {
            audioSource.mute = bgMuted;
        }
    }
    
    public void PlaySFX(string sfxName)
    {
        switch(sfxName)
        {
            case "opendoor":
                SoundObjectCreation(openDoor);
                break;
            case "marketdooropen":
                SoundObjectCreation(marketDoorOpen);
                break;
            case "changeuniform":
                SoundObjectCreation(changeUniform);
                break;
            case "lightflicker":
                SoundObjectCreation(lightsFlicker);
                break;
            case "openbox":
                SoundObjectCreation(boxOpen);
                break;
            case "placebox":
                SoundObjectCreation(placeBox);
                break;
            case "mouseclick":
                SoundObjectCreation(mouseClick);
                break;
            case "doorknocks":
                SoundObjectCreation(doorKnocks);
                break;
            case "somethingoutside":
                SoundObjectCreation(somethingOutside);
                break;
        }
    }

    void SoundObjectCreation(AudioClip clip)
    {
        if (sfxMuted)
        {
            return;
        }
        //Create SoundObject gameobject
        GameObject newObject = Instantiate(soundObject, transform);
        //Assign audioclip to its audiosource
        newObject.GetComponent<AudioSource>().clip = clip;
        //Play the audio
        newObject.GetComponent<AudioSource>().Play();
    }

    public void PlayMusic(string musicName)
    {
        switch(musicName)
        {
            case "room":
                MusicObjectCreation(roomMusic);
                break;
            case "supermarket":
                MusicObjectCreation(marketMusic);
                break;
            case "outside":
                MusicObjectCreation(outsideMusic);
                break;
            case "storageroom":
                MusicObjectCreation(storageroomMusic);
                break;
            case "hallapartment":
                MusicObjectCreation(hallapartmentMusic);
                break;
            case "die":
                MusicObjectCreation(die);
                break;
            case "menu":
                MusicObjectCreation(menu);
                break;
        }
    }

    void MusicObjectCreation(AudioClip clip)
    {
        //Check if there's an existing music object, if so delete it
        if(currentMusicObject)
           Destroy(currentMusicObject);
        //Create SoundObject gameobject
        currentMusicObject = Instantiate(bgsoundObject, transform);
        //Assign audioclip to its audiosource
        currentMusicObject.GetComponent<AudioSource>().clip = clip;
        //Make the audio source looping
        currentMusicObject.GetComponent<AudioSource>().loop = true;
        //Play the audio
        currentMusicObject.GetComponent<AudioSource>().Play();
    }

    // Method to toggle mute state for SFX sound
    public void ToggleSFXMute()
    {
        sfxMuted = !sfxMuted;

        // Save mute state to PlayerPrefs
        PlayerPrefs.SetInt("SFXMuted", sfxMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    // Method to toggle mute state for BG sound
    public void ToggleBGSoundMute()
    {
        bgMuted = !bgMuted;

        // Mute or unmute all BG audio sources
        foreach (AudioSource audioSource in bgAudioSources)
        {
            audioSource.mute = bgMuted;
        }

        // Save mute state to PlayerPrefs
        PlayerPrefs.SetInt("BGSoundMuted", bgMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    // Method to handle sceneLoaded event
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reapply mute state to BG audio sources when a scene is loaded
        foreach (AudioSource audioSource in bgAudioSources)
        {
            audioSource.mute = bgMuted;
        }
    }
}
