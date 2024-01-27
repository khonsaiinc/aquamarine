using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 horizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if(DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        horizontal.x =  Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + horizontal * speed * Time.deltaTime);
    }

}
