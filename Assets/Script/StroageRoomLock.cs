using UnityEngine;


public class StroageRoomLock : MonoBehaviour
{
    [SerializeField] GameObject doorStorageRoom;
    [SerializeField] GameObject interactIconStorageRoom;
    void Start()
    {
        if (QuestCheck.isUnlockStorageRoom)
        {
            interactIconStorageRoom.SetActive(true);
            doorStorageRoom.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            interactIconStorageRoom.SetActive(false);
            doorStorageRoom.SetActive(false);
        }
    }


}

