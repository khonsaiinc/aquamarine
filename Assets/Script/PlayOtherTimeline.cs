using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class PlayOtherTimeline : MonoBehaviour
{
    [SerializeField] PlayableDirector hinaMoveTimeline;


    public void StartOtherTimeline()
    {
        hinaMoveTimeline.Play();
    }
}

