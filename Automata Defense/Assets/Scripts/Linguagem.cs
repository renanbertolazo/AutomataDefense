using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Linguagem {
    public List<string> palavras { get; set; }
    public string dir_imagem { get; set; }

    public Texture2D textura_imagem;

    public Linguagem(List<string> p, string dir) {
        palavras = p;
        dir_imagem = dir;
        textura_imagem = null;
    }

    public Linguagem(List<string> p, Texture2D textura) {
        palavras = p;
        dir_imagem = null;
        textura_imagem = textura;
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