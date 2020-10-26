using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Jogo : MonoBehaviour
{   
    public int nivel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChecaGameOver();
        AtualizaStatusJogador();
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
