using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Linguagem {
    public List<string> palavras { get; set; }
    public string dir_imagem { get; set; }

    public Linguagem(List<string> p, string dir) {
        palavras = p;
        dir_imagem = dir;
    }

    public Linguagem() {
        
    }

    public void printar() {
        foreach (string item in palavras) {
            Debug.Log(item);
        }
        Debug.Log(dir_imagem);
    }

    public string Random_Palavra() {
        string palavra = null;
        int valor = 0;
        if(palavras.Count > 0) {
            valor = Random.RandomRange(0,palavras.Count-1);
            palavra = palavras[valor];
        }
        
        
        return palavra;
    }
}