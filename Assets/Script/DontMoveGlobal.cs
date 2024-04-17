using UnityEngine;

    public class DontMoveGlobal : MonoBehaviour
    {
        PlayerController playerController;
        [SerializeField] bool canMove;

        void Start()
        {
            canMove = true;
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        void Update()
        {
            if(canMove)
            {
                playerController.speed = playerController.baseSpeed;
                playerController.playAnimMove = true;
            }
            else
            {
                playerController.speed = 0;
                playerController.playAnimMove = false;
                playerController.animator.Rebind();
            }
        }

        public void PlayerCanMove(bool allowMove)
        {
            canMove = allowMove;
        }
    }

