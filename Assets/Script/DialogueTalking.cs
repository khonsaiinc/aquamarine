using UnityEngine;

    public class DialogueTalking : MonoBehaviour
    {
        public SetVase setVase;
        public TakedaOutside takedaOutside;

        void Start()
        {
            if(setVase == null)
                return;
            if(takedaOutside == null)
                return;
            
        }
    }

