using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
//using UnityEngine.Random;

public class GeradorPalavra : MonoBehaviour {
    // Start is called before the first frame update
    public static GeradorPalavra Instance { get; private set; }

    public List<Linguagem> linguagens_facil;
    public List<Linguagem> linguagens_medio;
    public List<Linguagem> linguagens_dificil;

    public List<Linguagem> linguagens_utilizadas = new List<Linguagem>();
    public GameObject Jogo;
    public GameObject GeradorLinguagem;
    
    public string alfabeto {get; set;}

    public GameObject image0;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    int aux = 0;
    int nivel = 0;

    public void Awake() {
        Instance = this;
        alfabeto = "abcd";

        nivel = Jogo.GetComponent<Jogo>().Nivel_Jogo();
        InsereLinguagem(nivel);
        aux = nivel;

        GeradorLinguagem = GameObject.Find("GeradorLinguagem");

        linguagens_facil = new List<Linguagem>(GeradorLinguagem.GetComponent<GeradorLinguagem>().linguagens_facil);
        linguagens_medio = new List<Linguagem>(GeradorLinguagem.GetComponent<GeradorLinguagem>().linguagens_medio);
        linguagens_dificil = new List<Linguagem>(GeradorLinguagem.GetComponent<GeradorLinguagem>().linguagens_dificil);
    }
    
    public void Update() {
        //print(Jogo.GetComponent<Jogo>().Nivel_Jogo());
        //print(GeradorLinguagem.GetComponent<GeradorLinguagem>().Oie());
        if(aux != nivel) {
            InsereLinguagem(nivel);
            aux = nivel;
        }
        
        nivel = Jogo.GetComponent<Jogo>().Nivel_Jogo();

        if(Input.GetKeyDown(KeyCode.K)){
            print(linguagens_utilizadas.Count);
            foreach(Linguagem item in linguagens_utilizadas) {
                print(item.dir_imagem);
            }
        } 
    }

    public void InsereLinguagem(int nivel) {
        switch(nivel) {
            case 1:
            linguagens_utilizadas.Add(Random_Linguagem(0));
                break;
            case 2:
            linguagens_utilizadas.Add(Random_Linguagem(0));    
                break;
            case 3:
            linguagens_utilizadas.Add(Random_Linguagem(0));    
                break;
            case 4:
            if(linguagens_utilizadas.Count > 3) 
                linguagens_utilizadas.RemoveAt(0);
            linguagens_utilizadas.Add(Random_Linguagem(1));     
                break;
            case 5:
            if(linguagens_utilizadas.Count > 3) 
                linguagens_utilizadas.RemoveAt(0);
            linguagens_utilizadas.Add(Random_Linguagem(1));      
                break;
            case 6:
            if(linguagens_utilizadas.Count > 3) 
                linguagens_utilizadas.RemoveAt(0);
            linguagens_utilizadas.Add(Random_Linguagem(1));      
                break;
            case 7:
            if(linguagens_utilizadas.Count > 3) 
                linguagens_utilizadas.RemoveAt(0);
            linguagens_utilizadas.Add(Random_Linguagem(2));      
                break;
            case 8:
            if(linguagens_utilizadas.Count > 3) 
                linguagens_utilizadas.RemoveAt(0);
            linguagens_utilizadas.Add(Random_Linguagem(2));      
                break;
            case 9:
            if(linguagens_utilizadas.Count > 3) 
                linguagens_utilizadas.RemoveAt(0);
            linguagens_utilizadas.Add(Random_Linguagem(2));      
                break;
        }
    }

    public string GeraPalavra(int tipo) {
        /* System.Random rnd = new System.Random();
        int tamanho  = rnd.Next(1, 4);
        string palavra = string.Empty;;
        for (int i = 0; i < tamanho; i++) {
            palavra += alfabeto[rnd.Next(alfabeto.Length)];
        }
        return palavra; */

        //tipo 0 para monstros e 1 para civis

        Linguagem random = new Linguagem();

        if(tipo == 0) {
            if(nivel < 4) {
                random = Random_Linguagem_Utilizada(0);
            } else {
                random = Random_Linguagem_Utilizada(1);
            }
        } else { 
            random = linguagens_utilizadas[0];
        }

        
        return random.Random_Palavra();
        //return "aa";
    }

    private int RandomValue(int ini, int fim) {
        //return UnityEngine.Random.RandomRange(ini, fim);
        return UnityEngine.Random.RandomRange(ini, fim+1);
    }

    public Linguagem Random_Linguagem_Utilizada(int ini) {
        Linguagem linguagem = new Linguagem();
        UnityEngine.Random rand = new UnityEngine.Random();

        //int valor = UnityEngine.Random.RandomRange(0,linguagens_utilizadas.Count-1);
        int valor = RandomValue(ini,linguagens_utilizadas.Count-1);
        linguagem = linguagens_utilizadas[valor];

        return linguagem;
    }
    public Linguagem Random_Linguagem(int value) {
        Linguagem linguagem = new Linguagem();
        UnityEngine.Random rand = new UnityEngine.Random();
        //System.Random random = new System.Random();
        //UnityEngine.Random.InitState((int)Time.time);
        
        if(value == 0) {
            //int valor = UnityEngine.Random.RandomRange(0,linguagens_facil.Count-1);
            int valor = RandomValue(0,linguagens_facil.Count-1);
            linguagem = linguagens_facil[valor];
        
            linguagens_facil.Remove(linguagem);
        }
        if(value == 1) {
            //int valor = UnityEngine.Random.RandomRange(0,linguagens_medio.Count-1);
            int valor = RandomValue(0,linguagens_medio.Count-1);
            linguagem = linguagens_medio[valor];

            linguagens_medio.Remove(linguagem);
        }
        if(value == 2) {
            //int valor = UnityEngine.Random.RandomRange(0,linguagens_dificil.Count-1);
            int valor = RandomValue(0,linguagens_dificil.Count-1);
            linguagem = linguagens_dificil[valor];

            linguagens_dificil.Remove(linguagem);
        }
        if(value == 3) {
            //int valor = UnityEngine.Random.RandomRange(0,linguagens_utilizadas.Count-1);
            int valor = RandomValue(0,linguagens_utilizadas.Count-1);
            linguagem = linguagens_utilizadas[valor];
        }

        return linguagem;
    }

    public void AtualizaImagens() {
        try {
            if(nivel < 4) {
                image1.GetComponent<ImageLoader>().EnviarImagem(linguagens_utilizadas[0].dir_imagem);
                image2.GetComponent<ImageLoader>().EnviarImagem(linguagens_utilizadas[1].dir_imagem);
                image3.GetComponent<ImageLoader>().EnviarImagem(linguagens_utilizadas[2].dir_imagem);
            } else {
                image0.GetComponent<ImageLoader>().EnviarImagem(linguagens_utilizadas[0].dir_imagem);
                image1.GetComponent<ImageLoader>().EnviarImagem(linguagens_utilizadas[1].dir_imagem);
                image2.GetComponent<ImageLoader>().EnviarImagem(linguagens_utilizadas[2].dir_imagem);
                image3.GetComponent<ImageLoader>().EnviarImagem(linguagens_utilizadas[3].dir_imagem);
            }
            
        } catch(System.ArgumentOutOfRangeException) {
            Debug.Log("opa");
        }
        
    }
}
