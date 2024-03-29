using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class CutsceneCoffe : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject screenVideo;
    [SerializeField] RenderTexture screenTexture;

    void Start()
    {
        screenVideo.SetActive(false);
        videoPlayer.playOnAwake = false;

        if (QuestCheck.isPlayedCoffe)
        {
            Destroy(videoPlayer.gameObject);
            Destroy(gameObject);
        }

    }

    public void CutScenePlay()
    {
        StartCoroutine(CheckCutScene());
    }

    IEnumerator CheckCutScene()
    {
        screenTexture.Release();

        screenVideo.SetActive(true);
        videoPlayer.Play();

        yield return new WaitForSeconds(4f);

        screenVideo.SetActive(false);
        QuestCheck.isPlayedCoffe = true;

        screenTexture.Release(); // รีเซ็ต VideoScreen ให้เป็นสีดำ
        Destroy(videoPlayer.gameObject);
        Destroy(gameObject);
    }

}
