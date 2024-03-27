using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    void Awake() { instance = this; }

    //Sound Effects
    public AudioClip openDoor, marketDoorOpen, changeUniform, lightsFlicker;
    //BackGround Music
    //public AudioClip roomMusic, marketMusic, outsideMusic;
    //Current Music Object
    //public GameObject currentMusicObject;
    
    //Sound Object
    public GameObject soundObject;
    
    public void PlaySFX(string sfxName)
    {
        switch(sfxName)
        {
            case "opendoor":
                SoundObjectCreation(openDoor);
                break;
            case "changeuniform":
                SoundObjectCreation(changeUniform);
                break;
            case "marketdooropen":
                SoundObjectCreation(marketDoorOpen);
                break;
        }
    }

    void SoundObjectCreation(AudioClip clip)
    {
        //Create SoundObject gameobject
        GameObject newObject = Instantiate(soundObject, transform);
        //Assign audioclip to its audiosource
        newObject.GetComponent<AudioSource>().clip = clip;
        //Play the audio
        newObject.GetComponent<AudioSource>().Play();
    }

    /*public void PlayMusic(string musicName)
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
        }
    }

    void MusicObjectCreation(AudioClip clip)
    {
        //Check if there's an existing music object, if so delete it
        if(currentMusicObject)
           Destroy(currentMusicObject);
        //Create SoundObject gameobject
        currentMusicObject = Instantiate(soundObject, transform);
        //Assign audioclip to its audiosource
        currentMusicObject.GetComponent<AudioSource>().clip = clip;
        //Make the audio source looping
        currentMusicObject.GetComponent<AudioSource>().loop = true;
        //Play the audio
        currentMusicObject.GetComponent<AudioSource>().Play();
    }*/
}
