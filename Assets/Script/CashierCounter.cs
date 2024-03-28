using UnityEngine;
using UnityEngine.InputSystem;


public class CashierCounter : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] DontMoveGlobal playerController;
    [SerializeField] Transform standHere;
    [SerializeField] GameObject interactIcon;
    [SerializeField] FadingScreen fadingScreen;

    bool playerInRange;
    bool isEnterCashier;
    public bool isStartEvent;

    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            if (context.performed)
            {

                EnterCashier();

            }
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            if (!isEnterCashier)
            {
                interactIcon.SetActive(true);
            }
            else
            {
                interactIcon.SetActive(false); // เข้าไปแล้วให้ปิด interactIcon
            }
        }
        else
        {
            interactIcon.SetActive(false);
        }

        if (isStartEvent)
        {
            playerController.PlayerCanMove(false);
        }
    }
    void EnterCashier()
    {
        if (!isEnterCashier)
        {
            #region CashierEvent
            if (QuestCheck.orderQuest == 4)//เริ่ม Event วันแรก
            {
                if (QuestCheck.orderQuest == 4)
                {
                    QuestManager.instance.OnCompleteQuest();
                }
                //เริ่มเล่น C3 ถ้ายังไม่เคยเล่น
                if (!QuestCheck.isPlayedC3)
                {
                    isStartEvent = true;
                    fadingScreen.FadeIn();
                }
            }

            if (QuestCheck.orderQuest == 13)//เริ่ม Event วันที่ 2
            {
                if (QuestCheck.orderQuest == 13)
                {
                    QuestManager.instance.OnCompleteQuest();
                    fadingScreen.FadeIn();
                }
            }
            #endregion


            player.GetComponent<SpriteRenderer>().sortingOrder = -2;
            player.transform.position = standHere.position;
            isEnterCashier = true;
            playerController.PlayerCanMove(false);



        }
        else
        {
            if (!isStartEvent)
            {

                player.GetComponent<SpriteRenderer>().sortingOrder = 0;
                isEnterCashier = false;
                playerController.PlayerCanMove(true);
            }
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

