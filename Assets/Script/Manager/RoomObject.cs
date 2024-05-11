using UnityEngine;

public class RoomObject : MonoBehaviour {
    // ! sorting as orderQuest
    [SerializeField] GameObject RadioEvent2;
    [SerializeField] GameObject RadioEvent8;
    [SerializeField] GameObject RadioEvent11;

    void Update() {
        loadRadio();
    }

#region objectradio
    void loadRadio() {
        if (QuestCheck.orderQuest == 2) {
            RadioEvent2Script();
        }
        else if (QuestCheck.orderQuest == 4 || QuestCheck.orderQuest == 5 || QuestCheck.orderQuest == 6 || QuestCheck.orderQuest == 7) {
            DisableAllEvent();

        }
        else if (QuestCheck.orderQuest == 8) {
            DisableAllEvent();
            RadioEvent8Script();

        }
        else if (QuestCheck.orderQuest == 10){
            DisableAllEvent();
        }  
        else if (QuestCheck.orderQuest == 11) {
            DisableAllEvent();
            RadioEvent11Script();
        }
    }

    void DisableAllEvent ()
    {
        DestroyRadioEvent2Event();
        DestroyRadioEvent8Event();
        DestroyRadioEvent11Event();
    }

    void RadioEvent2Script(){
        RadioEvent2.SetActive(true);
    }

    void RadioEvent8Script(){
        DestroyRadioEvent2Event();
        RadioEvent8.SetActive(true);
    }
    void RadioEvent11Script(){
        DestroyRadioEvent8Event();
        RadioEvent11.SetActive(true);
    }

    void DestroyRadioEvent2Event() {
        RadioEvent2.SetActive(false);
    }
    void DestroyRadioEvent8Event() {
        RadioEvent8.SetActive(false);
    }
    void DestroyRadioEvent11Event() {
        RadioEvent11.SetActive(false);
    }
    

#endregion
}