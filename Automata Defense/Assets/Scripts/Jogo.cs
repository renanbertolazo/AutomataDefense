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
    public float tempo2;
    public GameObject Gerador;
    //public GameObject Monstro;
    // Start is called before the first frame update
    void Awake() {
        qtd_monstro = 0;
        qtd_civil = 0;
    }
    void Start() {
        nivel = 0;
        tempo = Time.time + 2;
        UpdateNivel();
        Mecanica();
    }

    // Update is called once per frame
    void Update() {
        ChecaGameOver();
        AtualizaStatusJogador();
        AtualizaNivel();
        if (qtd_monstro == 0 && qtd_civil == 0) {
            UpdateNivel();
            ChecaVitoria();
            Mecanica();
            tempo += 10;
        }
        GeradorMonstro();
    }

    private void GeradorMonstro() {
        if(Time.time > tempo) {
            bool invocado = false;
            tempo = Time.time + 2;
            float valorInteiro = Random.Range(0f,1f);
            if(qtd_civil == 0 && !invocado) {
                Gerador.GetComponent<Gerador>().InstanciaMonstro();
                qtd_monstro -=1;
                invocado = true; 
            }
            if(qtd_monstro == 0 && !invocado) {
                Gerador.GetComponent<Gerador>().InstanciaCivil();
                qtd_civil -=1;
                invocado = true;
            }
            if( qtd_civil !=0 && qtd_monstro!=0 && !invocado) {
                if(valorInteiro < 0.7f) {
                    Gerador.GetComponent<Gerador>().InstanciaMonstro();
                    qtd_monstro -=1; 
                }

                if(valorInteiro > 0.7f) {
                    Gerador.GetComponent<Gerador>().InstanciaCivil();
                    qtd_civil -=1;
                }
                invocado = true; 
            }
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
                qtd_monstro = 7;
                break;
            case 3:
                qtd_civil = 0;
                qtd_monstro = 9;
                break;
            case 4:
                qtd_civil = 3;
                qtd_monstro = 9;
                break;
            case 5:
                qtd_civil = 3;
                qtd_monstro = 9;
                break;
            case 6:
                qtd_civil = 3;
                qtd_monstro = 9;
                break;
            case 7:
                qtd_civil = 5;
                qtd_monstro = 15;
                break;
            case 8:
                qtd_civil = 5;
                qtd_monstro = 15;
                break;
            case 9:
                qtd_civil = 5;
                qtd_monstro = 15;
                break;
        }
        
    }
    private void ChecaGameOver() {
        if(RecursosJogador.Instance.IsGameOver()) {
            this.transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void ChecaVitoria() {
        if(nivel > 9 && qtd_civil == 0 && qtd_monstro == 0 && !RecursosJogador.Instance.IsGameOver()) {
            this.transform.GetChild(2).gameObject.SetActive(true);
            Time.timeScale = 0;
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
        .gameObject.transform.GetChild(4)
        .GetComponent<Text>().text = RecursosJogador.Instance.vidaJogador.ToString();

        //info Score do Jogador
        this.transform.GetChild(1)
        .gameObject.transform.GetChild(0)
        .gameObject.transform.GetChild(5)
        .GetComponent<Text>().text = RecursosJogador.Instance.scoreJogador.ToString();
        
    }

    private void AtualizaNivel() {
        this.transform.GetChild(5)
        .gameObject.transform.GetChild(0)
        .gameObject.transform.GetChild(1)
        .GetComponent<Text>().text = nivel.ToString();

    }
    public int Nivel_Jogo() {
        return nivel;
    }
}
