using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace DS
{
    public class VidioSoundControler : MonoBehaviour
    {
        [SerializeField] AudioManager audioManager;
        public VideoPlayer videoPlayer;

        // Start is called before the first frame update
        void Start()
        {
            /*if (videoPlayer == null)
            {
                videoPlayer = GetComponent<VideoPlayer>();
                if (videoPlayer == null)
                {
                    Debug.LogError("VideoPlayer not found or assigned to the VideoSoundController.");
                    return;
                }
            }*/
        }

        // Update is called once per frame
        void Update()
        {
            /*if (audioManager == null)
            {
                Debug.LogError("AudioManager not assigned to the VideoSoundController.");
                return;
            }*/

            if (audioManager.sfxMuted == true)
            {
                videoPlayer.SetDirectAudioVolume(0, 0);
            }
            else if (audioManager.sfxMuted == false)
            {
                videoPlayer.SetDirectAudioVolume(0, 1);
            }
            
            
        }
    }
}
