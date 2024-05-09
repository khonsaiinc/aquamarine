using UnityEngine;

public class RoomObject : MonoBehaviour {
    [SerializeField] GameObject RadioDay1;
    [SerializeField] GameObject interactIcon;

    void Update() {
        if (QuestCheck.orderQuest == 0 ||QuestCheck.orderQuest == 1 || QuestCheck.orderQuest == 2 || QuestCheck.orderQuest == 3) {
            RadioDay1Script();
        }
        else
        {
            DestroyGameObject();
        }
    }
    void RadioDay1Script(){
        RadioDay1.SetActive(true);
    }

    void DestroyGameObject() {
        Destroy(RadioDay1);
        Destroy(interactIcon);
    }
}