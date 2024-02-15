using UnityEngine;


public class DoorRoomTrigger : MonoBehaviour
{
        
        [SerializeField] GameObject postMan;
        
        void OnTriggerStay2D(Collider2D coll)
        {
            if(coll.tag == "Player")
            {
                if(postMan != null)
                {
                    postMan.SetActive(true);
                }
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        void OnTriggerExit2D(Collider2D coll)
        {
                if(postMan != null)
                {
                    postMan.SetActive(false);
                }
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
}
