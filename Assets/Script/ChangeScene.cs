using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;
using System.Net.Http;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneChange(int sceneNumber)
    {
        UnityEngine.Debug.Log("change scene!!!");
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
    }

    public void PrintApple(){
        UnityEngine.Debug.Log("APPPLEZ");
    }
}
