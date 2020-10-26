using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Scrip referente a vida e score do jogador.
public class RecursosJogador : MonoBehaviour {   
    //instancia global, pois com prefab nao eh possivel acessar esse script sem ser global
    public static RecursosJogador Instance { get; private set; }

    public int vidaJogador;
    public int scoreJogador;
    public bool gameOver;

    private void Awake() {
        //colocando a instancia global para ser o objeto
        Instance = this;
    }
    // Start is called before the first frame update
    void Start() {
        vidaJogador = 30;
        scoreJogador = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if(vidaJogador == 0){
            Debug.Log("Game Over");
            GameOver(true);
        }
        //Debug.Log(vidaJogador);
    }
    public void GameOver(bool status) {
        gameOver = status;
    }

    public bool IsGameOver() {
        if(gameOver) return true;
        else return false;
    }
    public void AumentaVida(int valor) {
        vidaJogador += valor;
        //Debug.Log(vidaJogador);
    }

    public void DiminuiVida(int valor) {
        vidaJogador -= valor;
        //Debug.Log(vidaJogador);
    }

    public void AumentaScore(int valor) {
        scoreJogador += valor;
    }

    public void DiminuiScore(int valor) {
        scoreJogador -= valor;
    }

}
