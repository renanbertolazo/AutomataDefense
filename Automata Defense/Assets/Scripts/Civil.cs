using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Civil : MonoBehaviour {   
    public int vida = 100;

    public string palavra;
    //public GameObject Torre;
    // Start is called before the first frame update
    void Awake() {
        //transform.tag = "Player";
        //print ("Hello World!");
        //palavra = GeradorDePalavra();
        
        palavra = GeradorPalavra.Instance.GeraPalavra();
        this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(palavra);
        //palavra = children.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
        
        
    }


    void Start() {
        //palavra = GeradorPalavra.Instance.GeraPalavra();
        //this.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(palavra);
        this.gameObject.GetComponent<AIDestinationSetter>().target = Chegada.Instance.gameObject.transform;
    }

    // Update is called once per frame
    void Update() {
        VerificaVida();

        //Vector3 alvo = new Vector3(2f,0f,0f);
        //transform.position = Vector3.MoveTowards(transform.position, alvo, 1f*Time.deltaTime*2);
        
    }

    void Move() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * 2;
    }

    void VerificaVida() {
        if (vida <= 0) {
            Destroy(this.gameObject,0);
            //score aumentando bruscamente precisa concertar..
            RecursosJogador.Instance.DiminuiScore(1);
        }
    }

    public void TiraVida(int valor) {

        vida -= valor;
    }
    public void SetVida(int valor) {

        vida = valor;
    }

    private string GeradorDePalavra() {
        
        string resultado = "Civil";
        
        return resultado;
    }
}
