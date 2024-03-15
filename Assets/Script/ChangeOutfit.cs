using UnityEngine;
using UnityEngine.InputSystem;


public class ChangeOutfit : MonoBehaviour
{
    SetVase setVase;
    BedSleep bedSleep;
    [SerializeField] BoxCollider2D wardrobeTrigger;
    [SerializeField] GameObject interactIcon;
    [SerializeField] PlayerController playerController;
    bool playerInRange;

    public AudioSource source;
    public AudioClip clip;
    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            interactIcon.SetActive(true);
            if (context.performed)
            {
                source .PlayOneShot(clip);
                //เปลี่ยนชุด
                if (QuestCheck.orderQuest == 1 || QuestCheck.orderQuest == 10)
                {
                    playerController.HinaChangeOutfit("WorkUniform");

                    wardrobeTrigger.enabled = false;

                    QuestCheck.canChangeOutfit = false;
                    QuestManager.instance.OnCompleteQuest();
                }
                else if (QuestCheck.orderQuest == 7)
                {
                    playerController.HinaChangeOutfit("YellowPajama");

                    wardrobeTrigger.enabled = false;

                    QuestCheck.canChangeOutfit = false;
                    QuestManager.instance.OnCompleteQuest();
                    if (QuestCheck.orderQuest == 8)
                    {
                        setVase.CheckBox();
                        bedSleep.bedTrigger.enabled = true;
                    }
                }
            }
        }
    }

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        setVase = GameObject.Find("Box").GetComponent<SetVase>();
        bedSleep = GameObject.Find("BedSleep").GetComponent<BedSleep>();
        if (QuestCheck.canChangeOutfit)
        {
            WardrobeOpen();
        }
        else
        {
            wardrobeTrigger.enabled = false;
        }
    }

    public void WardrobeOpen()
    {
        if (QuestCheck.canChangeOutfit)
        {
            wardrobeTrigger.enabled = true;
        }
    }

    #region IconShow
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
