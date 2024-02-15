using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenceUI : MonoBehaviour
{
    public void NextScence()
    {
        SceneManager.LoadScene("Room");
    }
}

