using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour 
{
    public GameObject player; // will reference to the player game object's position
    private Vector3 offset; //will set the offset position from player to the camera

    // Start is called before first frame update
    void Start()
    {

        // calculate the offset position between the camera and the player at the start of the game
        //it substracts the player's position from the camera's
        offset = transform.position - player.transform.position;
        
    }

    // Update is called once per frame 
    void Update()
    {
        //sets the camera to where the player is plus the offset set above
        transform.position = player.transform.position + offset;

    }
}
