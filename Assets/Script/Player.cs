using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public Inventory inventory;
    // public static Vector3 playerPosition;

    // public Task task;

    private void Awake()
    {
        inventory = new Inventory(33);
        UnityEngine.Debug.Log("Sceneeee Awake" + SceneManager.GetActiveScene().buildIndex);
        // if (SceneManager.GetActiveScene().buildIndex != 1) // Change this to the index of the level you want to save the player's position data for
        // {
        // DontDestroyOnLoad(this.gameObject);
        // }
        // task = new Task(7);
    }

    // void OnLevelWasLoaded(int level)
    // {
    //     UnityEngine.Debug.Log("Sceneeee OnLevelWasLoaded" + SceneManager.GetActiveScene().buildIndex);
    //     // playerPosition = transform.position;
    //     // if (level != 2) // Change this to the index of the level you want to save the player's position data for
    //     // {
    //     //     playerPosition = transform.position;
    //     // }
    // }
}
