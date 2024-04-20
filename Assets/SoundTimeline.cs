using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Audio;

namespace DS
{
    public class SoundTimeline : MonoBehaviour
    {
        [SerializeField] string sfxname;
        // Start is called before the first frame update
        public void Start()
        {
            AudioManager.instance.PlaySFX(sfxname);
        
        }

        // Update is called once per frame
        /*void Update()
        {
        
        }*/
    }
}
