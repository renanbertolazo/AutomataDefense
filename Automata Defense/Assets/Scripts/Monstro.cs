using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Monstro : MonoBehaviour
{
    
    void Awake()
    {
        //this.gameObject.GetComponent<AIDestinationSetter>().target = Chegada.Instance.gameObject.transform;

        //Debug.Log(Chegada.Instance.GetTransform().position);
    }

    // Start is called before the first frame update
    void Start()
    {   
        // Coloca o transform da chegada alvo
        Debug.Log(Chegada.Instance.GetTransform().position);
        this.gameObject.GetComponent<AIDestinationSetter>().target = Chegada.Instance.gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        //Vector3 alvo = new Vector3(2f,0f,0f);
        //transform.position = Vector3.MoveTowards(transform.position, alvo, 1f*Time.deltaTime*2);
        
       
    }

}
