using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class ScenceUI : MonoBehaviour
{
    [Header("UI & Buttons",order = 0)]
    [SerializeField] GameObject button;
    [SerializeField] GameObject backgroundScreen;

    [Header("VideoPlayer",order = 1)]
    [SerializeField] VideoPlayer videoPlayer;
    void Start()
    {
        videoPlayer.playOnAwake = false;
    }

    public void NextScence()
    {
        StartCoroutine(isPlayingCutscene());
    }

    IEnumerator isPlayingCutscene()
    {
        button.SetActive(false);
        
        yield return new WaitForSeconds(1f);
        backgroundScreen.SetActive(false);

        videoPlayer.Play();

        yield return new WaitForSeconds(22f);

        SceneManager.LoadScene("Room");
    }
}

