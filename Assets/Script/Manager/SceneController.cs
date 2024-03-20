using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneController : MonoBehaviour
{
    GameObject player;
    public List<Transform> transformsSpawn; //ลำดับเป็นของอีก scene ถัดไป
    public string currentScene;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        CheckAndSpawn();

        QuestCheck.sceneBefore = currentScene;

    }

    public void CheckAndSpawn()
    {
        switch (QuestCheck.sceneBefore)
        {
            case "Room":
                if (currentScene == "Outside")
                {
                    player.transform.position = transformsSpawn[0].position;//เกิดที่ประตู Apartment(ข้างนอก)
                    break;
                }else if (currentScene == "HallApartment")
                {
                    player.transform.position = transformsSpawn[0].position;//เกิดหน้าห้องของ hina
                }
                break;
            case "Outside":
                if (currentScene == "SuperMarket")
                {
                    player.transform.position = transformsSpawn[0].position;//เกิดที่ประตู supermarket(ข้างใน)
                }
                else if (currentScene == "Room")
                {
                    player.transform.position = transformsSpawn[0].position;//เกิดที่ประตู Apartment(ข้างใน)
                }
                break;
            case "SuperMarket":
                if (currentScene == "Outside")
                {
                    player.transform.position = transformsSpawn[1].position;//เกิดที่ประตู supermarket(ข้างนอก)
                }
                else if (currentScene == "StorageRoom")
                {
                    player.transform.position = transformsSpawn[0].position;//เกิดที่ประตู StorageRoom(ข้างใน)
                }
                break;
            case "StorageRoom":
                if (currentScene == "SuperMarket")
                {
                    player.transform.position = transformsSpawn[1].position; //เกิดที่ประตู StorageRoom(ข้างนอก)
                }
                break;
            default:
                currentScene = "Room";
                break;
        }
    }
}

