using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chegada : MonoBehaviour {   
    public static Chegada Instance { get; private set; }
    
    private void Awake() {
        //colocando a instancia global para ser o objeto
        Instance = this;
    }

    public Transform GetTransform() {
        return this.gameObject.transform;
    }

    //DETECTA SE O OBJETO QUE COLIDIU É DA TAG PLAYER, E DESTROI O OBJETO, E DIMINUI A VIDA E O SCORE
    public void OnCollisionEnter2D(Collision2D collision2D) {   
        //Debug.Log("Colidiu");
        //If the object we collided with was a Runner and not a Catcher.
        if (collision2D.gameObject.tag == "Player") {
            /*
            Destroy(collision2D.gameObject,0);
            RecursosJogador.Instance.DiminuiVida(1);
            RecursosJogador.Instance.DiminuiScore(1);
            */
            if(collision2D.gameObject.transform.GetComponent<Monstro>()) {
                Destroy(collision2D.gameObject,0);
                RecursosJogador.Instance.DiminuiVida(1);
                RecursosJogador.Instance.DiminuiScore(1);
            }
            if(collision2D.gameObject.transform.GetComponent<Civil>()) {
                Destroy(collision2D.gameObject,0);
                RecursosJogador.Instance.AumentaScore(1);
            }
        }
    }
}