using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDuplicateMenu : MonoBehaviour
{
    Pause p ;
    EnableMenu off;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Canvas").GetComponent<Pause>();
        p.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
