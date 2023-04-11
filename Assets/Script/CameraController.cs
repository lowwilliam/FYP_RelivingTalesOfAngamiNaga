using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
     void Start()
    {
        // Mark the camera object as "Don't Destroy On Load"
        // DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Update the camera position to follow the player
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        // transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
