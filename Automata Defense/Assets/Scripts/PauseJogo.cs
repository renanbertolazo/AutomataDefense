using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseJogo : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    public void Pause() {
        Time.timeScale = 0;
    }
    
    public void Despause() {
        Time.timeScale = 1;
    }
}