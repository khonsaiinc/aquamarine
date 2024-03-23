using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneTimeline : MonoBehaviour
{
    public void OnLoadScene()
    {
        SceneManager.LoadScene("SuperMarket");
    }
}
