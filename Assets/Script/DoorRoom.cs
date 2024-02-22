using UnityEngine;

    public class DoorRoom : MonoBehaviour
    {
        [SerializeField] GameObject door;
        void Start()
        {
            if(QuestCheck.questDelivery)
            {
                door.SetActive(QuestCheck.questDelivery);
            }
        }
    }
