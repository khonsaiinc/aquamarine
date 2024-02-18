using System.Collections;
using UnityEngine;
    public class SetVase : MonoBehaviour
    {
        [SerializeField] GameObject vase;
        [SerializeField] GameObject NPC; 
        
        public void ShowVaseImage()
        {
            vase.SetActive(true);
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
