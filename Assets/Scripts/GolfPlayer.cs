using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfPlayer : MonoBehaviour
{
    [SerializeField] private float shotPower;
    [SerializeField]private LineRenderer lineRenderer;
    private bool isIdle;
    private bool ToggleAim;
    private Rigidbody rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ToggleAim = false;
        lineRenderer.enabled = false;
        

    }



    private void Update()
    { 
        if (rb.velocity.magnitude < 0.21f) {
            Stop();
        }
        ProcessAim();
        
    }

    private void Stop() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isIdle = true;
        
       

    }
    // collision trigger when ball enters radius of power-up
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedB"))
        {
            Debug.Log("picked up");
            other.gameObject.SetActive(false);
        }
    }


private void DrawLine(Vector3 worldPoint)
    {
        Vector3[] positions = { transform.position, worldPoint };
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;
    }

    

    private void OnMouseDown() //if mouse clicked on ball and if it's not moving, toggle the aim lines
    {
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
            
        }

    }

    private void Shoot(Vector3 worldPoint) {
        ToggleAim = false;
        
        lineRenderer.enabled = false;
        Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);
        Vector3 direction = (-horizontalWorldPoint - -transform.position).normalized;
        float strength = Vector3.Distance(transform.position, horizontalWorldPoint);

        rb.AddForce(direction * strength * shotPower);
        Debug.Log("Speed: " + rb.velocity.magnitude);

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
