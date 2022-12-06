using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blades : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (this.gameObject.tag == "Spin")
        {
            transform.Rotate(0f, 0.6f, 0f, Space.Self);
        }
        else {
            transform.Rotate(0f, 0f, 0.3f, Space.Self);
        }
    }
}
