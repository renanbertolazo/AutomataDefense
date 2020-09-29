using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pos : MonoBehaviour
{
    public Civil civil1;
    public Text pos1; 
    // Update is called once per frame
    void Update()
    {   
        Vector3 vector = new Vector3(civil1.transform.position.x,civil1.transform.position.y,civil1.transform.position.z);
        pos1.text = "vector.toString()"; 
    }
}
