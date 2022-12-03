using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    float yPos; 
    void Start()
    {
        yPos = transform.position.y;
    }
    float index;
    float y;
    
    float amplitudeY = 0.1f;
    // Update is called once per frame
    void Update()
    {
        index += Time.deltaTime;
        y = Mathf.Abs(amplitudeY * Mathf.Sin(index));
        Debug.Log(y);
        this.transform.position = new Vector3(transform.position.x, y + yPos, transform.position.z);


    }

    
    
}
