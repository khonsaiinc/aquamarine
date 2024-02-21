using System.Collections;
using UnityEngine;
using UnityEngine.Video;
public class CutsceneSM : MonoBehaviour
{
    //Cutscene C2

    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject screenVideo;

    void Start()
    {
        screenVideo.SetActive(false);
        videoPlayer.playOnAwake = false;
        if(QuestCheck.isPlayedC2)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is Here");
            StartCoroutine(CheckCutScene());
        }
    }

    IEnumerator CheckCutScene()
    {
        playerController.enabled = false;
        screenVideo.SetActive(true);
        videoPlayer.Play();
        yield return new WaitForSeconds(3f);
        playerController.enabled = true;
        screenVideo.SetActive(false);
        QuestCheck.isPlayedC2 = true;
        Destroy(gameObject);
    }

}
