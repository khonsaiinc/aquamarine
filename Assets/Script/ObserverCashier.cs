using UnityEngine;


public class ObserverCashier : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] bool isEndEventDay1;
    public bool canMove; // เช็คหลังจากออกเคาร์เตอร์ (จบเปลี่ยนกะ)

    void EnableMove()
    {
        playerController.enabled = true;
    }
    void DisableMove()
    {
        playerController.enabled = false;
    }
}
