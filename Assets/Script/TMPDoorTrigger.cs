using Unity.VisualScripting;
using UnityEngine;

namespace DS
{
    public class TMPDoorTrigger : MonoBehaviour
    {
        
        [SerializeField] GameObject door;

        void OnTriggerStay2D(Collider2D coll)
        {
            if(coll.tag == "Player")
            {
                door.SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        void OnTriggerExit2D(Collider2D coll)
        {
                door.SetActive(false);
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
