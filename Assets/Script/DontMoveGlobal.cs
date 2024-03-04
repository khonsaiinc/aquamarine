using UnityEngine;

    public class DontMoveGlobal : MonoBehaviour
    {
        PlayerController playerController;
        bool canMove;

        void Start()
        {
            canMove = true;
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        void Update()
        {
            if(canMove)
            {
                playerController.enabled = true;
            }
            else
            {
                playerController.enabled = false;
            }
        }

        public void PlayerCanMove(bool allowMove)
        {
            canMove = allowMove;
        }
    }

