using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    private float horizontal;
    [SerializeField] private float speed = 1f;
    private bool isFacingRight = true;

    [Header("AnimationController")]
    [SerializeField] RuntimeAnimatorController brownPajama;
    [SerializeField] RuntimeAnimatorController workUniform;
    [SerializeField] RuntimeAnimatorController workUniform_Holdingbox;
    [SerializeField] RuntimeAnimatorController yellowPajama;

    void Start()
    {
        HinaChangeOutfit(QuestCheck.outFit);
    }
    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void HinaChangeOutfit(string nameOutfit)
    {
        switch (nameOutfit)
        {
            case "BrownPajama":
                animator.runtimeAnimatorController = brownPajama; //ชุดนอนสีน้ำตาล
                QuestCheck.outFit = nameOutfit; // บันทึกชุดสำหรับไปซีนอื่น
                break;
            case "WorkUniform":
                animator.runtimeAnimatorController = workUniform; //ชุดทำงาน
                QuestCheck.outFit = nameOutfit; // บันทึกชุดสำหรับไปซีนอื่น
                break;
            case "WorkUniform_HoldingBox":
                animator.runtimeAnimatorController = workUniform_Holdingbox; //ชุดทำงาน
                QuestCheck.outFit = nameOutfit; // บันทึกชุดสำหรับไปซีนอื่น
                break;
            case "YellowPajama":
                animator.runtimeAnimatorController = yellowPajama; //ชุดนอนสีเหลือง
                QuestCheck.outFit = nameOutfit;// บันทึกชุดสำหรับไปซีนอื่น
                break;
            default:
                Debug.LogError("Can't found Outfit");
                break;
        }
    }
}
