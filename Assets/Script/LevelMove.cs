using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;
    private GameManage gameManage;

    private void OnTriggerEnter2D(Collider2D other) {
        gameManage = GameObject.FindObjectOfType<GameManage>();
        print("detect gate entering!");
        print(other.tag);
        print(gameManage.GetGame());
        if (other.tag == "Player" && gameManage.GetGame() == 1 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            UnityEngine.Debug.Log("Trigger gate entering, switch scene to"+sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex,LoadSceneMode.Single);
        }
    }
}

