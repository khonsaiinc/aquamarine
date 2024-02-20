using System.Collections;
using UnityEngine;
    public class SetVase : MonoBehaviour
    {
        [SerializeField] GameObject box;
        [SerializeField] GameObject NPC; 
        
        void Start()
        {
            if(!QuestCheck.questDelivery)
            {
                box.SetActive(false);
            }
        }

        public void ShowVaseImage()
        {
            box.SetActive(true);
        }

        public void NPCDestroy()
        {
            StartCoroutine(DelayDestroyNPC());
        }

        IEnumerator DelayDestroyNPC()
        {
            Destroy(NPC);
            yield return new WaitForSeconds(0.3f);
        }
    }
