using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Civil : MonoBehaviour
{   
    public GameObject children;
    public float speed;
    public int vida = 100;

    public string palavra;
    //public GameObject Torre;
    // Start is called before the first frame update
    void Awake()
    {
        //transform.tag = "Player";
        //print ("Hello World!");
        palavra = GeradorDePalavra();
        //palavra = children.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
        children.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(palavra);
    }

    // Update is called once per frame
    void Update() {
        Move();
        VerificaVida();
    }

    void Move() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * 2;
    }

    void VerificaVida() {
        if (vida == 0) {
            Destroy(this.gameObject,0);
            //score aumentando bruscamente precisa concertar..
            RecursosJogador.Instance.DiminuiVida(1);
        }
    }

    
    //void OnMouseDown(){

        //Destroy(this.gameObject,0);

    //}
    
    public void SetVida(int valor) {

        vida = valor;
    }

    private string GeradorDePalavra() {
        
        string resultado = "Hello men";
        
        return resultado;
    }
}
