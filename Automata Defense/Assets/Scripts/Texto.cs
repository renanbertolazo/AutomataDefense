using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texto : MonoBehaviour {   
    public GameObject player;
    void Awake() {
        //Debug.Log(transform.position);
        //Debug.Log(transform.tag);
        transform.position = player.transform.position;
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {   
        Vector3 movimento = new Vector3(player.transform.position.x, player.transform.position.y+0.5f, 0f);
        transform.position = movimento;
        
    }
}
