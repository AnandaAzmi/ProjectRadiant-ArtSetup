using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToLobbyScene : MonoBehaviour
{
    public void ChangeSceneByName(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log("Pindah ke Main menu atau lobby ya.. thank you guyss.. mangatss");
        }
        else
        {
            Debug.LogError("Scene name is empty or null!");
        }
    }
}
