using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Jogo : MonoBehaviour
{   
    public int nivel;
    public int qtd_monstro;
    public int qtd_civil;
    public float tempo;
    public GameObject Gerador;
    //public GameObject Monstro;
    // Start is called before the first frame update
    void Start() {
        nivel = 0;
        qtd_monstro = 0;
        tempo = 0;
    }

    // Update is called once per frame
    void Update() {
        ChecaGameOver();
        AtualizaStatusJogador();
        if (qtd_monstro == 0) {
            UpdateNivel();
            Mecanica();
        }
        GeradorMonstro();
    }

    private void GeradorMonstro() {
        if(Time.time > tempo) {
                tempo = Time.time + 2;
                Gerador.GetComponent<Gerador>().InstanciaMonstro();
                qtd_monstro -=1;
        }
    }

    private void UpdateNivel() {
        nivel += 1;
    }
    private void Mecanica() {
        switch(nivel) {
            case 1:
                qtd_civil = 0;
                qtd_monstro = 5;
                break;
            case 2:
                qtd_civil = 0;
                qtd_monstro = 6;
                break;
            case 3:
                qtd_civil = 0;
                qtd_monstro = 7;
                break;
            case 4:
                qtd_civil = 0;
                qtd_monstro = 5;
                break;
            case 5:
                qtd_civil = 0;
                qtd_monstro = 5;
                break;
            case 6:
                qtd_civil = 0;
                qtd_monstro = 5;
                break;
            case 7:
                qtd_civil = 0;
                qtd_monstro = 5;
                break;
            case 8:
                qtd_civil = 0;
                qtd_monstro = 5;
                break;
            case 9:
                qtd_civil = 0;
                qtd_monstro = 5;
                break;
        }
        
    }
    private void ChecaGameOver() {
        if(RecursosJogador.Instance.IsGameOver()) {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void IrParaMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void ReiniciarJogo() {
        SceneManager.LoadScene("Jogo");
    }

    private void AtualizaStatusJogador() {
        //info Vida do Jogador
        this.transform.GetChild(1)
        .gameObject.transform.GetChild(0)
        .gameObject.transform.GetChild(0)
        .GetComponent<Text>().text = "Vida: "+RecursosJogador.Instance.vidaJogador.ToString();

        //info Score do Jogador
        this.transform.GetChild(1)
        .gameObject.transform.GetChild(0)
        .gameObject.transform.GetChild(1)
        .GetComponent<Text>().text = "Score: "+RecursosJogador.Instance.scoreJogador.ToString();
    }
}
