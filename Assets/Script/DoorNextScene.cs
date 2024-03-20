using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class DoorNextScene : MonoBehaviour
{
    [SerializeField] GameObject interactIcon;
    [SerializeField] Transform spawnPlayer;
    [SerializeField] SceneController sceneController;
    [SerializeField] FaderScreen faderScreen;

    [TextArea(minLines: 1, maxLines: 2)]
    [SerializeField] string locationName; //ใส่ชื่อ scene ที่จะโหลด ปล.ตัวอักษรต้องตรงเหมือนกันหมด
    bool playerInRange;
    public AudioSource source;
    public AudioClip clip;

    public void interact(InputAction.CallbackContext context)
    {
        if (playerInRange)
        {
            if (context.performed)
            {
                source .PlayOneShot(clip);
                StartCoroutine(DoorEnter());
            }
        }
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

    IEnumerator DoorEnter()
    {
        faderScreen.FadeIn(); // เรียก fade in
        yield return new WaitForSeconds(faderScreen.fadeSpeed); // รอเท่ากับเวลาการ fade
        SceneManager.LoadScene(locationName);
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

