using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
//using UnityEngine.Random;

public class GeradorPalavra : MonoBehaviour {
    // Start is called before the first frame update
    public static GeradorPalavra Instance { get; private set; }
    
    public string alfabeto {get; set;}

    public void Awake() {
        Instance = this;
        alfabeto = "abcd";
    }

    public string GeraPalavra() {

        System.Random rnd = new System.Random();
        int tamanho  = rnd.Next(1, 4);
        string palavra = string.Empty;;
        for (int i = 0; i < tamanho; i++) {
            palavra += alfabeto[rnd.Next(alfabeto.Length)];
        }

        return palavra;
    }
}
