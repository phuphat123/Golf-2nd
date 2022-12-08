using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GolfPlayer : MonoBehaviour
{
    [SerializeField] private float shotPower;
    [SerializeField]private LineRenderer lineRenderer;
    [SerializeField] private float maxPower;
    [SerializeField] private LayerMask m_golfDragLayerTarget;
    private Rigidbody rb;

    

    public float rotationSpeed = 50.0f;
    private Vector3 prev;

    [Header("Debug")]
    public float currentVelocity;
    [SerializeField]private bool isIdle;
    [SerializeField]private bool ToggleAim;
    [SerializeField]private bool onRamp;
    [SerializeField] private bool Grounded;
    [SerializeField] private Material m;
    [SerializeField]private bool initShotbool;

    public AudioClip shootSound, stopSound;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ToggleAim = false;
        lineRenderer.enabled = false;
        rb.maxAngularVelocity = 1000;
        
        
        
    }

    
    
    private void Update()
    {
        currentVelocity = rb.velocity.magnitude;


        

        if (rb.velocity.magnitude < 0.2f)
        {
            
            
            ProcessAim();

        }
        else
        {
            rb.velocity = rb.velocity * 0.9995f;    //deceleration across frames
        }

        if (transform.position.y < -5)
        {
            transform.position = new Vector3(prev.x, prev.y, prev.z);
            Stop();  //respawn function
        }

        


    }

    private bool played;
    void checkStopSound() {
        if (isIdle && played == false)
        {
            AudioSource.PlayClipAtPoint(stopSound, transform.position);
            played = true;
        }
        
    }

    private void FixedUpdate()
    {

        if (Grounded == false) {
            return;
        }

        if (initShotbool == true) {
            return;
        }

        if (rb.velocity.magnitude < 0.2f && onRamp == false) //ramp detection
        {
        Stop();
            
        }
        
        


    }

    
    
    IEnumerator initShot() {
        initShotbool = true;

        yield return new WaitForSecondsRealtime(1);
        initShotbool = false; 
    }
    public void Stop() {

        prev = transform.position;
        Debug.Log("Previous Location: " + prev);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isIdle = true;
        checkStopSound();

    }

    
    // collision trigger 
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Ramp")) {
            onRamp = true;
            Debug.Log("onRamp true");
            
        }

       
        
 
    }

     

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ramp"))
        {
            onRamp = false;
            Debug.Log("onRamp false");
            Grounded = false;

        }
        
        
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged") {
            Grounded = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            Grounded = false;
        }
    }



    private void DrawLine(Vector3 worldPoint)   //draws line between ball and mouse
    {
        Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);
        Vector3[] positions = { transform.position, horizontalWorldPoint };
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;
    }

    private void OnMouseDown() //if mouse clicked on ball and if it's not moving, toggle the aim lines
    {
        Debug.Log("Push");
        if (isIdle) {
            ToggleAim = true;
        }
    }



    private void ProcessAim() {
        Debug.Log("Processing Aim");
        if (!ToggleAim || !isIdle) {
            return;         //if ball is not clicked, and ball is moving, don't do anything
        }
        Vector3? worldPoint = CastMouseClickRay();
        Debug.Log("worldPoint: " + worldPoint);
        if (!worldPoint.HasValue)
        {
            return;
        }

        
        DrawLine(worldPoint.Value);

        if (Input.GetMouseButtonUp(0)) {
            Shoot(worldPoint.Value);
            Debug.Log("Release");
        }

    }

    private void Shoot(Vector3 worldPoint) {
        
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
        
        StartCoroutine(initShot());
        ToggleAim = false;
        isIdle = false;
        played = false;
        lineRenderer.enabled = false;
        Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);
        Vector3 direction = (-horizontalWorldPoint - -transform.position).normalized;   // direction vector
        float strength = Vector3.Distance(transform.position, horizontalWorldPoint);    //if the line is longer, the more strength

        

        rb.AddForce(direction * strength * shotPower);
        Debug.Log(rb.velocity.magnitude);
    }

    private Vector3? CastMouseClickRay() {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        if (Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity, m_golfDragLayerTarget))
        {
            return hit.point;
        }
        else {
            return null;
        }
    }

}
