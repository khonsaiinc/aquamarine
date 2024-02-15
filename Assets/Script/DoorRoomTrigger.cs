using UnityEngine;


public class DoorRoomTrigger : MonoBehaviour
{
        
        [SerializeField] GameObject door;

        void OnTriggerStay2D(Collider2D coll)
        {
            if(coll.tag == "Player")
            {
                if(door != null)
                {
                    door.SetActive(true);
                }
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        void OnTriggerExit2D(Collider2D coll)
        {
                if(door != null)
                {
                    door.SetActive(false);
                }
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
}
