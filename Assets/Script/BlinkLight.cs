using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class BlinkLight : MonoBehaviour
{
    [SerializeField] float waitForBlink = 3;
    [SerializeField] int totalBlink;
    float durationBlink = 1;
    [SerializeField] float intervalBlink = 3;

    [SerializeField] Light2D light2D;
    [SerializeField] Light2D rimLight2d;

    private void Start()
    {
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitForBlink);

            float totalTimeBlink = durationBlink / intervalBlink;

            for (int i = 0; i < totalBlink; i++)
            {
                light2D.enabled = false;
                rimLight2d.enabled = false;
                yield return new WaitForSeconds(totalTimeBlink);
                light2D.enabled = true;
                rimLight2d.enabled = true;
                yield return new WaitForSeconds(totalTimeBlink);
                Debug.Log(totalTimeBlink + " / " + i);
            }
        }

    }
}

