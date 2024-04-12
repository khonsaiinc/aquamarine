using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchLayer : MonoBehaviour
{
    [SerializeField] SpriteRenderer hinaSpriteRenderer;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && QuestCheck.outFit == "WorkUniform_HoldingBox")
        {
            hinaSpriteRenderer.sortingLayerName = "ObjectFront";
            hinaSpriteRenderer.sortingOrder = 100;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            hinaSpriteRenderer.sortingLayerName = "Default";
            hinaSpriteRenderer.sortingOrder = 0;
        }
    }
}

