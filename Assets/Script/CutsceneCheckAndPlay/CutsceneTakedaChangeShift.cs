using System.Collections;
using UnityEngine;
using UnityEngine.Video;


public class CutsceneTakedaChangeShift : MonoBehaviour
{
    
// CutScene C4
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject screenVideo;
    [SerializeField] RenderTexture screenTexture;

    void Start()
    {
        screenVideo.SetActive(false);
        videoPlayer.playOnAwake = false;

        if (QuestCheck.isPlayedC4) // ทำลาย gameobject เมื่อเคยเล่นไปแล้ว
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
        QuestCheck.isPlayedC4 = true;

        screenTexture.Release(); // รีเซ็ต VideoScreen ให้เป็นสีดำ

        Destroy(videoPlayer.gameObject);
        Destroy(gameObject);
    }

    

}

