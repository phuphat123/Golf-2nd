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
    private Vector3 defaultRotation;

    [SerializeField] private Camera cam;
    void awake()
    {
        
    }

    // Update is called once per frame
    private bool drag = false;

    public Vector3 offset;
    
    public Transform player;

    private Vector3 previousPosition;


    private Vector3 trackPos;
    


     
    void Update()
    {

        
        // Camera follows the player with specified offset position
        // Check if the right mouse button is held down
        if (Input.GetMouseButtonDown(1)) {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        
        if (Input.GetMouseButton(1)) {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);
            cam.transform.position = player.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            cam.transform.Translate(new Vector3(0, 0, -10));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            
        }
        cam.transform.position = player.position;
        cam.transform.Translate(new Vector3(0, 0, -10));

        


    }
        

    


}
