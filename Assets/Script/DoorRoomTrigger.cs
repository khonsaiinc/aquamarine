using UnityEngine;
using UnityEngine.InputSystem;


public class DoorRoomTrigger : MonoBehaviour
{
        [SerializeField] GameObject interactIcon;
        [SerializeField] GameObject postMan;
        bool playerInRange;
        bool isClosed;

        public void interact(InputAction.CallbackContext context)
        {
            if (playerInRange)
            {
                if(context.performed)
                {
                    DoorSwitch();
                }
            }
        }

        public void DoorSwitch()
        {
            isClosed = !isClosed;

            if(isClosed)
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }
        }

    #region DoorFunction
        void OpenDoor()
        {
            postMan.SetActive(true);
            Debug.Log("Door is Open");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    
        void CloseDoor()
        {
            postMan.SetActive(false);
            Debug.Log("Door is Closed");
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    #endregion

    #region ShowInteractIcon
        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.gameObject.CompareTag("Player"))
            {
                interactIcon.SetActive(true);
                playerInRange = true;
            }
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            if(collider.gameObject.CompareTag("Player"))
            {
                interactIcon.SetActive(false);
                playerInRange = false;
            }
        }
#endregion

}