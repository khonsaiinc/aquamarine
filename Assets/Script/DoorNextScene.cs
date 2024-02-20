using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class DoorNextScene : MonoBehaviour
{
    [SerializeField] GameObject interactIcon;
    [SerializeField] Transform spawnPlayer;
    [SerializeField] GameObject player;

    [TextArea(minLines: 1, maxLines: 2)]
    [SerializeField] string locationName; //ใส่ชื่อ scene ที่จะโหลด ปล.ตัวอักษรต้องตรงเหมือนกันหมด

    bool playerInRange;

    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            if (context.performed)
            {
                DoorEnter();
            }
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (QuestCheck.fistStart)
        {
            player.transform.position = spawnPlayer.position;
        }else{QuestCheck.fistStart = true;}
    }

    void Update()
    {
        if (playerInRange)
        {
            interactIcon.SetActive(true);
        }
        else
        {
            interactIcon.SetActive(false);
        }
    }

    public void DoorEnter()
    {
        SceneManager.LoadScene(locationName);
    }

    #region CheckCollider Player
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

