using UnityEngine;
using UnityEngine.Video;
using UnityEngine.InputSystem;
using System.Collections;


public class DoorRoomTrigger : MonoBehaviour
{
    [SerializeField] GameObject interactIcon;
    //[SerializeField] PlayerController playerController;
    [SerializeField] GameObject postMan;

    [Header("Door")]
    [SerializeField] GameObject DoorPostMan;
    [SerializeField] GameObject doorReal;
    [SerializeField] GameObject doorFake;

    [Header("Video")]
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject screenVideo;
    bool playerInRange;
    bool isClosed;
    bool isPlayed;

    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            if (context.performed)
            {
                DoorSwitch();
            }
        }
    }

    void Start()
    {
        screenVideo.SetActive(false);

        if (QuestCheck.questDelivery)
        {
            doorReal.SetActive(true);
            Destroy(DoorPostMan);
            Destroy(postMan);
        }
        else { doorReal.SetActive(false); }
    }

    void Update()
    {
        if (playerInRange)
        {
            if (postMan != null)
            {
                if (!postMan.activeInHierarchy)
                {
                    interactIcon.SetActive(true);
                }
                else interactIcon.SetActive(false);

            }
        }
        else
        {
            interactIcon.SetActive(false);
        }

        if (postMan == null)
        {
            QuestCheck.questDelivery = true;
            doorReal.SetActive(true);
            Destroy(DoorPostMan);
        }
    }

    public void DoorSwitch()
    {
        isClosed = !isClosed;

        if (!isPlayed)
        {
            StartCoroutine(isVideoEnd());
        }

        if (isClosed)
        {
            if (postMan != null)
            {
                interactIcon.SetActive(false);
            }

            OpenDoor();

            if (doorFake != null)
            {
                doorFake.SetActive(true);
            }
        }
        else
        {
            if (postMan == null)
            {
                if (doorFake != null)
                {
                    Destroy(doorFake);
                }

                CloseDoor();
            }
        }
    }

    IEnumerator isVideoEnd()
    {
        isPlayed = true;
        screenVideo.SetActive(true);
        videoPlayer.Play();
        yield return new WaitForSeconds(3f);
        screenVideo.SetActive(false);
    }

    #region DoorFunction
    void OpenDoor()
    {
        if (postMan != null)
        {
            interactIcon.SetActive(false);
            postMan.SetActive(true);
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void CloseDoor()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    #endregion

    #region ShowInteractIcon
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    #endregion

}