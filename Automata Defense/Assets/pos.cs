using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pos : MonoBehaviour
{
    public GameObject civil;
    public Text pos1; 
    public Civil opa;
    // Update is called once per frame
    public void Update()
    {   
        // = GetComponent<RectTransform>();
        
        pos1 = GetComponent<Text>();
        pos1.text = "oiii "+ transform.localPosition;
        //transform.localPosition += civil.transform.position * Time.deltaTime * 5;
        //print (civil.GetComponent<Civil>().vida);
        opa = civil.GetComponent<Civil>();
        opa.SetVida(0);
        //Vector3 vector = new Vector3(civil1.transform.position.x,civil1.transform.position.y,civil1.transform.position.z);
        //pos1.text = "vector.toString()"; 
    }
}
