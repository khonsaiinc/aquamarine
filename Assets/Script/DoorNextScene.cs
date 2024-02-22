using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class DoorNextScene : MonoBehaviour
{
    [SerializeField] GameObject interactIcon;
    [SerializeField] Transform spawnPlayer;
    GameObject player;
    [SerializeField] SceneController sceneController;

    [TextArea(minLines: 1, maxLines: 2)]
    [SerializeField] string locationName; //ใส่ชื่อ scene ที่จะโหลด ปล.ตัวอักษรต้องตรงเหมือนกันหมด


    string proviousScene;
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
        proviousScene = QuestCheck.sceneBefore;
        CheckRightSpawn();
        player = GameObject.FindGameObjectWithTag("Player");
        if (QuestCheck.fistStart)
        {
            player.transform.position = spawnPlayer.position;
        }
        else { QuestCheck.fistStart = true; }
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

    void CheckRightSpawn()
    {
        switch (proviousScene)
        {
            case "Room":
                spawnPlayer.position = sceneController.transformsSpawn[0].position; //เกิดที่ประตู Apartment(ข้างนอก)
                QuestCheck.sceneBefore = locationName; //ฉากปัจจุบันจะกลายเป็นฉากก่อนหน้า(proviousScene) เมื่อเริ่มซีนถัดไป
                break;
            case "Outside":
                spawnPlayer.position = sceneController.transformsSpawn[0].position; //เกิดที่ประตู supermarket(ข้างใน)
                QuestCheck.sceneBefore = locationName; //ฉากปัจจุบันจะกลายเป็นฉากก่อนหน้า(proviousScene) เมื่อเริ่มซีนถัดไป
                break;
            case "SuperMarket":
                switch (locationName)
                {
                    case "Outside":
                        spawnPlayer.position = sceneController.transformsSpawn[1].position;
                        break;
                    case "StorageRoom":
                        spawnPlayer.position = sceneController.transformsSpawn[0].position;
                        break;
                    default:
                        Debug.LogError("Location ERROR!!");
                        break;
                }
                QuestCheck.sceneBefore = locationName; //ฉากปัจจุบันจะกลายเป็นฉากก่อนหน้า(proviousScene) เมื่อเริ่มซีนถัดไป
                break;
            case "StorageRoom":
                spawnPlayer.position = sceneController.transformsSpawn[0].position; //เกิดที่ประตู StorageRoom(ข้างนอก)
                QuestCheck.sceneBefore = locationName; //ฉากปัจจุบันจะกลายเป็นฉากก่อนหน้า(proviousScene) เมื่อเริ่มซีนถัดไป
                break;
            default:
                Debug.LogError("Location ERROR!!");
                break;
        }
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

