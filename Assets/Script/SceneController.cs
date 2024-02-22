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
                }
                break;
            case "Outside":
                if (currentScene == "SuperMarket")
                {
                    player.transform.position = transformsSpawn[0].position;//เกิดที่ประตู Apartment(ข้างนอก)
                }
                else if (currentScene == "Room")
                {
                    player.transform.position = transformsSpawn[0].position;//เกิดที่ประตู supermarket(ข้างน้อง)
                }
                break;
            case "SuperMarket":
                if (currentScene == "Outside")
                {
                    player.transform.position = transformsSpawn[1].position;//เกิดที่ประตู Apartment(ข้างนอก)
                }
                else if (currentScene == "StorageRoom")
                {
                    player.transform.position = transformsSpawn[0].position;//เกิดที่ประตู supermarket(ข้างน้อง)
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

