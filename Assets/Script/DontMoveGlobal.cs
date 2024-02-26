using UnityEngine;

    public class DontMoveGlobal : MonoBehaviour
    {
        [SerializeField] PlayerController playerController;
        [SerializeField] bool canMove;

        void Start()
        {
            canMove = true;
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

