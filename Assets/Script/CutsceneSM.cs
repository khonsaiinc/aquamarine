using System.Collections;
using UnityEngine;
using UnityEngine.Video;
public class CutsceneSM : MonoBehaviour
{
    //Cutscene ตัวเอกเดินข้างนอก

    VideoPlayer videoPlayer;
    PlayerController playerController;

    void Start()
    {
        videoPlayer.playOnAwake = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            videoPlayer.playOnAwake = true;
            playerController.enabled = false;
            CheckCutScene();
        }
    }

    IEnumerator CheckCutScene()
    {
        yield return new WaitForSeconds(3f);
        playerController.enabled = true;
        Destroy(gameObject);
    }

}
