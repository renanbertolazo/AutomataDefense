using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreColisor : MonoBehaviour
{   
    public GameObject Torre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Torre.transform.position;
    }
}
