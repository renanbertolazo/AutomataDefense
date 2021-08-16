using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chegada : MonoBehaviour {   
    public static Chegada Instance { get; private set; }

    public int qtd_monstro_civil = 0;
    
    private void Awake() {
        //colocando a instancia global para ser o objeto
        Instance = this;
    }

    public Transform GetTransform() {
        return this.gameObject.transform;
    }

    public void Atualiza_Monstro_Civil(int qtd_monstro, int qtd_civil) {
        qtd_monstro_civil = qtd_monstro + qtd_civil + qtd_monstro_civil;
    }
    public int Checa_Monstro_Civil() {
        return qtd_monstro_civil;
    }

    public void Diminui_Monstro_Civil() {
        qtd_monstro_civil -= 1;
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
                RecursosJogador.Instance.DiminuiScore(10);
            }
            if(collision2D.gameObject.transform.GetComponent<Civil>()) {
                Destroy(collision2D.gameObject,0);
                RecursosJogador.Instance.AumentaScore(10);
            }

            qtd_monstro_civil -= 1;
        }
    }
}