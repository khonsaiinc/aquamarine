using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; 
    public string playerTag = "Player";
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    void Update()
    {
        if (player != null)
        {
            
            Vector3 moveDirection = (player.position - transform.position).normalized;

            Collider2D[] colliders = Physics2D.OverlapBoxAll(player.position, new Vector2(1f, 1f), 0f);
            bool playerOnBoxCollider = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("StalkerStop")) // ! Set Tag as "Stalkerstop"
                {
                    playerOnBoxCollider = true;
                    break;
                }
            }

            // Move the enemy towards the player if not on a box collider
            if (!playerOnBoxCollider)
            {
                rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
            }
            else
            {
                // If the player is on a box collider, stop moving
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            // If the player is not found, stop moving
            rb.velocity = Vector2.zero;
        }
    }
}
