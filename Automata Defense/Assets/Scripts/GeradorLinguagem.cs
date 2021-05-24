using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;
using System.IO;
using System.Linq;
//using Linguagem;

/*
public class Linguagem {
    public List<string> palavras { get; set; }
    public string dir_imagem { get; set; }

    public Linguagem(List<string> p, string dir) {
        palavras = p;
        dir_imagem = dir;
    }

    public void printar() {
        foreach (string item in palavras) {
            Debug.Log(item);
        }
        Debug.Log(dir_imagem);
    }
}*/

public class GeradorLinguagem : MonoBehaviour { 

    public List<Linguagem> linguagens_facil = new List<Linguagem>();
    public List<Linguagem> linguagens_medio = new List<Linguagem>();
    public List<Linguagem> linguagens_dificil = new List<Linguagem>();
    public string texto_palavras;
    List<string> palavras = new List<string>();
    public int dificuldade;
    public string path_imagem;
    public GameObject InputPalavras;
    public GameObject InputImagem;
    public GameObject InputDificuldade;

    public void Awake() {
        DontDestroyOnLoad(this.gameObject);
        
        Linguagem ling0 = new Linguagem(new List<string>(),"C:/Users/renan/Desktop/teste2.jpg");
        Linguagem ling1 = new Linguagem(new List<string>(),"C:/Users/renan/Desktop/teste2.jpg");
        Linguagem ling2 = new Linguagem(new List<string>(),"C:/Users/renan/Desktop/teste2.jpg");
        Linguagem ling3 = new Linguagem(new List<string>(),"C:/Users/renan/Desktop/teste2.jpg");
        Linguagem ling4 = new Linguagem(new List<string>(),"C:/Users/renan/Desktop/teste2.jpg");
        Linguagem ling5 = new Linguagem(new List<string>(),"C:/Users/renan/Desktop/teste2.jpg");
        Linguagem ling6 = new Linguagem(new List<string>(),"C:/Users/renan/Desktop/teste2.jpg");
        Linguagem ling7 = new Linguagem(new List<string>(),"C:/Users/renan/Desktop/teste2.jpg");
        Linguagem ling8 = new Linguagem(new List<string>(),"C:/Users/renan/Desktop/teste2.jpg");

        linguagens_facil.Add(ling0);
        linguagens_facil.Add(ling1);
        linguagens_facil.Add(ling2);

        linguagens_medio.Add(ling3);
        linguagens_medio.Add(ling4);
        linguagens_medio.Add(ling5);

        linguagens_dificil.Add(ling6);
        linguagens_dificil.Add(ling7);
        linguagens_dificil.Add(ling8);

    }
    public void Start() {
        dificuldade = 0;
    }

    public string Oie() {
        return "oii";
    }
    public Linguagem Random_Linguagem(List<Linguagem> linguagens) {
        int valor = UnityEngine.Random.Range(0,linguagens.Count);
        int i = 0;
        Linguagem linguagem = new Linguagem();

        foreach(Linguagem item in linguagens) {
            if(valor == i) {
                linguagem = item;
                break;
            }
            i++;
        }

        return linguagem;
    }
    public void Carrega_Dificuldades() {

        if(InputDificuldade.transform.GetComponent<Dropdown>().value == 0)
            dificuldade = 0;
        if(InputDificuldade.transform.GetComponent<Dropdown>().value == 1)
            dificuldade = 1;
        if(InputDificuldade.transform.GetComponent<Dropdown>().value == 2)
            dificuldade = 2;

        //print("Dificuldade: "+dificuldade);
    }

    public void Carrega_Image_Path() {
        path_imagem = InputImagem.GetComponent<InputField>().text;
        //print("Caminho da imagem: "+path_imagem);
    }

    public void Carrega_Palavras() {
        string[] lines;

        texto_palavras = InputPalavras.GetComponent<InputField>().text;
        
        lines = texto_palavras.Split ('\n');

        lines = lines.Where(w => !string.IsNullOrEmpty(w)).ToArray();    
        
        /*byte[] asciiBytes = Encoding.ASCII.GetBytes(lines[0]);
        foreach(byte b in asciiBytes) {
            print(b);
            //print(Convert.ToChar(b));
        }*/
        //print("Linhas: " +lines.Length);
        /*foreach (string item in lines) {
            print(item);
            print("tamanho linha "+ item.Length);
        }*/
        foreach (string item in lines) {
            int i = 0;
            string palavra = null;

            while(i < item.Length) {
                //print(item[i]);
                if(item[i] == ',' || item[i] == '\0' || item[i] == '\r') {
                    //print(palavra);
                        if(palavra != null){
                            //print(palavra);
                            palavras.Add(palavra);
                            palavra = null;
                        }  
                } else {
                    
                    if((item[i] != ' ') && !Equals(item[i], "\0") && (item[i] != '\r')){
                    palavra += item[i];
                    //print(palavra);
                        if(i == item.Length-1 ) {
                            if(palavra != null) {
                                //print(palavra);
                                palavras.Add(palavra);
                                palavra = null;
                            }    
                        }
                    }
                }

                i++;
            }
        }

        //print(palavras[4].Length);
        Carrega_Image_Path();
        InsereLinguagem();
        printa();
    }

    public void InsereLinguagem() {
        List<string> p = new List<string>(palavras);
        Linguagem linguagem = new Linguagem(p, path_imagem);
        //print("opa");
        //linguagem.printar();

        if(dificuldade ==0)
            linguagens_facil.Add(linguagem);
        if(dificuldade ==1)
            linguagens_medio.Add(linguagem);
        if(dificuldade ==2)
            linguagens_dificil.Add(linguagem);

        palavras.Clear();
        //path_imagem = null;
        Mensagem();
    }

    public void Mensagem() {
        InputPalavras.GetComponent<InputField>().text = "";
        InputImagem.GetComponent<InputField>().text = "";


    }

    public void Delete_Linguagens() {
        linguagens_facil = new List<Linguagem>();
        linguagens_medio = new List<Linguagem>();
        linguagens_dificil = new List<Linguagem>();
    }

    public void printa() {
        /*
        Debug.Log("Dificuldade: "+dificuldade);
        foreach (string item in palavras) {
            print("Palavra: "+item+" Tamanho: "+item.Length);
        }
        Debug.Log(path_imagem);*/

        foreach (Linguagem item in linguagens_facil) {
            print("faceis");
            foreach (string x in item.palavras) {
                print(x);
            }
            print(item.dir_imagem);
            //item.printar();
        }
        foreach (Linguagem item in linguagens_medio) {
            print("medias");
            item.printar();
        }
        foreach (Linguagem item in linguagens_dificil) {
            print("dificeis");
            item.printar();
        }
    }
}
