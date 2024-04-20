using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class SceneCheck : MonoBehaviour
    {
        //[SerializeField] AudioManager audioManager;
        [SerializeField] string Musicname;
        //public GameObject bgsoundObject;
        // Start is called before the first frame update
        void Start()
        {
            AudioManager.instance.PlayMusic(Musicname);
        }

        // Update is called once per frame
        /*void Update()
        {
            if(audioManager.bgMuted == true)
            {
                bgsoundObject.mute
            }
        
        }*/
    }
}
