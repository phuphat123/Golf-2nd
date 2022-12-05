using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private bool canMove;
    // Start is called before the first frame update

    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;
    
    void awake()
    {
        
    }

    // Update is called once per frame
    private bool drag = false;

    public Vector3 offset;
    public Transform player;
    void Update()
    {

        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z); // Camera follows the player with specified offset position
        // Check if the right mouse button is held down
        if (Input.GetMouseButton(1))
        {
            // Get the movement of the mouse in x and y direction
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            // Rotate the camera based on the movement of the mouse
            transform.Rotate(-y, x, 0);
        }                                                                                                                            
    }
        

    


}
