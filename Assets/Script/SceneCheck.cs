using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class SceneCheck : MonoBehaviour
    {
        [SerializeField] string Musicname;
        // Start is called before the first frame update
        void Start()
        {
            AudioManager.instance.PlayMusic(Musicname);
        }

        // Update is called once per frame
        /*void Update()
        {
        
        }*/
    }
}
