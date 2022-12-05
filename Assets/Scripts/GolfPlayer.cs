using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GolfPlayer : MonoBehaviour
{
    [SerializeField] private float shotPower;
    [SerializeField]private LineRenderer lineRenderer;
    private bool isIdle;
    private bool ToggleAim;
    private Rigidbody rb;

    public float speed;
    private float boostTimer;
    private bool boosting;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ToggleAim = false;
        lineRenderer.enabled = false;
        rb.maxAngularVelocity = 1000;
        speed = 3;
        boostTimer = 0;
        boosting = false;
    }


    private void Update()
    {
        if (rb.velocity.magnitude < 0.2f)
        {
            ProcessAim();
        }
        else {
            rb.velocity = rb.velocity * 0.9995f;
        }

        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if(boostTimer >= 3)
            {
                speed = 3;
                boostTimer = 0;
                boosting = false;
            }
        }
        
    }


    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < 0.2f && onRamp == false)
        {
            Stop();
        }


    }


    

    private void Stop() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isIdle = true;
    }

    bool onRamp;
    // collision trigger 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedB")) // checks if tag of game objects for SpeedB
        {
            boosting = true;
            speed = 10;
            Debug.Log("picked up");
            other.gameObject.SetActive(false); // disables speedb object
        }
        if (other.gameObject.CompareTag("Hole"))
        {
            Debug.Log("Hole potted! Proceed to Next level!");

        }
        if (other.gameObject.CompareTag("Ramp")) {
            onRamp = true;
            Debug.Log("onRamp true");
            Invoke("setBoolRamp",1);
        }

    }
    void setBoolRamp() {
        onRamp = false;
    }


    private void DrawLine(Vector3 worldPoint)
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
        if (!ToggleAim || !isIdle) {
            return;         //if ball is not clicked, and ball is moving, don't do anything
        }
        Vector3? worldPoint = CastMouseClickRay();

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

        


        ToggleAim = false;
        isIdle = false;
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
        if (Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity))
        {
            return hit.point;
        }
        else {
            return null;
        }
    }

}
