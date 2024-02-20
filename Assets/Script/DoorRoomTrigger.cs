using UnityEngine;
using UnityEngine.InputSystem;


public class DoorRoomTrigger : MonoBehaviour
{
    [SerializeField] GameObject interactIcon;
    [SerializeField] GameObject postMan;
    [SerializeField] GameObject DoorPostMan;
    [SerializeField] GameObject doorReal;
    [SerializeField] GameObject doorFake;

    bool playerInRange;
    bool isClosed;


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
        if(QuestCheck.questDelivery)
        {
            doorReal.SetActive(true);
            Destroy(DoorPostMan);
            Destroy(postMan);
        }else{doorReal.SetActive(false);}
    }

    void Update()
    {
        if (playerInRange)
        {
            if(postMan != null)
            {
                if(!postMan.activeInHierarchy)
                {
                    interactIcon.SetActive(true);
                }else interactIcon.SetActive(false);
                
            }
        }
        else
        {
            interactIcon.SetActive(false);
        }

        if(postMan == null)
        {
            QuestCheck.questDelivery = true;
            doorReal.SetActive(true);
            Destroy(DoorPostMan);
        }
    }

    public void DoorSwitch()
    {
        isClosed = !isClosed;

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

    #region DoorFunction
    void OpenDoor()
    {
        if (postMan != null)
        {
            interactIcon.SetActive(false);
            postMan.SetActive(true);
        }
        Debug.Log("Door is Open");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void CloseDoor()
    {
        //postMan.SetActive(false);
        Debug.Log("Door is Closed");
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