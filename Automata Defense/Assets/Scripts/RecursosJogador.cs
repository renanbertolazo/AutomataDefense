using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursosJogador : MonoBehaviour
{   

    public int vidaJogador;
    public int scoreJogador;

    public bool gameOver;


    // Start is called before the first frame update
    void Start() {
        vidaJogador = 30;
        scoreJogador = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if(vidaJogador <=0){
            Debug.Log("Game Over");
            GameOver(true);
        }
    }
    public void GameOver(bool status) {
        gameOver = status;
    }
    public void AumentaVida(int valor) {
        vidaJogador =+ valor;
    }

    public void DiminuiVida(int valor) {
        vidaJogador =- valor;
    }

    public void AumentaScore(int valor) {
        scoreJogador =+ valor;
    }

    public void DiminuiScore(int valor) {
        scoreJogador =- valor;
    }

}
