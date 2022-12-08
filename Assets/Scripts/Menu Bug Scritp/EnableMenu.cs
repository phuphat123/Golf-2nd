using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMenu : MonoBehaviour {
    // Start is called before the first frame update
    Pause p;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Canvas").GetComponent<Pause>();
        p.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
