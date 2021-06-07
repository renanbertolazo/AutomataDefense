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
        /*
        Linguagem ling0 = new Linguagem(new List<string>(),@"C:\Users\renan\Desktop\Linguagens\Exp1.jpg");
        Linguagem ling1 = new Linguagem(new List<string>(),@"C:\Users\renan\Desktop\Linguagens\Exp2.jpg");
        Linguagem ling2 = new Linguagem(new List<string>(),@"C:\Users\renan\Desktop\Linguagens\Exp3.jpg");
        Linguagem ling3 = new Linguagem(new List<string>(),@"C:\Users\renan\Desktop\Linguagens\Exp4.jpg");
        Linguagem ling4 = new Linguagem(new List<string>(),@"C:\Users\renan\Desktop\Linguagens\Exp5.jpg");
        Linguagem ling5 = new Linguagem(new List<string>(),@"C:\Users\renan\Desktop\Linguagens\Exp6.jpg");
        Linguagem ling6 = new Linguagem(new List<string>(),@"C:\Users\renan\Desktop\Linguagens\Exp7.jpg");
        Linguagem ling7 = new Linguagem(new List<string>(),@"C:\Users\renan\Desktop\Linguagens\Exp8.jpg");
        Linguagem ling8 = new Linguagem(new List<string>(),@"C:\Users\renan\Desktop\Linguagens\Exp9.jpg");

        linguagens_facil.Add(ling0);
        linguagens_facil.Add(ling1);
        linguagens_facil.Add(ling2);

        linguagens_medio.Add(ling3);
        linguagens_medio.Add(ling4);
        linguagens_medio.Add(ling5);

        linguagens_dificil.Add(ling6);
        linguagens_dificil.Add(ling7);
        linguagens_dificil.Add(ling8);
        */

        InserirLinguagensFaceis();
        InserirLinguagensMedias();
        InserirLinguagensDificeis();

    }
    public void Start() {
        dificuldade = 0;
    }

    public string Oie() {
        return "oii";
    }

    private void InserirLinguagensFaceis() {
        List<string> facil_1 = new List<string>();
        facil_1.Add("01");
        facil_1.Add("010");
        facil_1.Add("0100");
        facil_1.Add("01000");
        facil_1.Add("010000");
        facil_1.Add("0100000");
        facil_1.Add("01000000");
        facil_1.Add("010000000");
        Linguagem linguagem_facil_1 = new Linguagem(facil_1,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\facil_1.jpg");

        List<string> facil_2 = new List<string>();
        facil_2.Add("1");
        facil_2.Add("01");
        facil_2.Add("10");
        facil_2.Add("010");
        facil_2.Add("00100");
        facil_2.Add("0100");
        facil_2.Add("100");
        facil_2.Add("0100");
        Linguagem linguagem_facil_2 = new Linguagem(facil_2,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\facil_2.jpg");

        List<string> facil_3 = new List<string>();
        facil_3.Add("1");
        facil_3.Add("11");
        facil_3.Add("111");
        facil_3.Add("1111");
        facil_3.Add("11111");
        facil_3.Add("111111");
        facil_3.Add("1111111");
        facil_3.Add("11111111");
        Linguagem linguagem_facil_3 = new Linguagem(facil_3,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\facil_3.jpg");

        List<string> facil_4 = new List<string>();
        facil_4.Add("1");
        facil_4.Add("01");
        facil_4.Add("11");
        facil_4.Add("001");
        facil_4.Add("111");
        facil_4.Add("101");
        facil_4.Add("011");
        facil_4.Add("00111");
        Linguagem linguagem_facil_4 = new Linguagem(facil_4,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\facil_4.jpg");

        List<string> facil_5 = new List<string>();
        facil_5.Add("01");
        facil_5.Add("0101");
        facil_5.Add("010101");
        facil_5.Add("01010101");
        facil_5.Add("0101010101");
        facil_5.Add("010101010101");
        facil_5.Add("01010101010101");
        facil_5.Add("0101010101010101");
        Linguagem linguagem_facil_5 = new Linguagem(facil_5,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\facil_5.jpg");
    
        linguagens_facil.Add(linguagem_facil_1);
        linguagens_facil.Add(linguagem_facil_2);
        linguagens_facil.Add(linguagem_facil_3);
        linguagens_facil.Add(linguagem_facil_4);
        linguagens_facil.Add(linguagem_facil_5);
    }

    private void InserirLinguagensMedias() {
        List<string> medio_1 = new List<string>();
        medio_1.Add("abc");
        medio_1.Add("aabbcc");
        medio_1.Add("aabc");
        medio_1.Add("abbc");
        medio_1.Add("abcc");
        medio_1.Add("abbcc");
        medio_1.Add("aabcc");
        medio_1.Add("aaabc");
        Linguagem linguagem_medio_1 = new Linguagem(medio_1,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\medio_1.jpg");

        List<string> medio_2 = new List<string>();
        medio_2.Add("abc");
        medio_2.Add("aac");
        medio_2.Add("ac");
        medio_2.Add("ab");
        medio_2.Add("aab");
        medio_2.Add("bbc");
        medio_2.Add("bbb");
        medio_2.Add("aaa");
        Linguagem linguagem_medio_2 = new Linguagem(medio_2,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\medio_2.jpg");

        List<string> medio_3 = new List<string>();
        medio_3.Add("abc");
        medio_3.Add("bc");
        medio_3.Add("bccc");
        medio_3.Add("b");
        medio_3.Add("abcc");
        medio_3.Add("aab");
        medio_3.Add("ab");
        medio_3.Add("aabcc");
        Linguagem linguagem_medio_3 = new Linguagem(medio_3,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\medio_3.jpg");

        List<string> medio_4 = new List<string>();
        medio_4.Add("abc");
        medio_4.Add("ac");
        medio_4.Add("abbc");
        medio_4.Add("aaaac");
        medio_4.Add("acccc");
        medio_4.Add("aaacccc");
        medio_4.Add("aaabbcccc");
        medio_4.Add("aabbbcccc");
        Linguagem linguagem_medio_4 = new Linguagem(medio_4,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\medio_4.jpg");

        List<string> medio_5 = new List<string>();
        medio_5.Add("01");
        medio_5.Add("001");
        medio_5.Add("011");
        medio_5.Add("000111");
        medio_5.Add("0001");
        medio_5.Add("0111");
        medio_5.Add("0011111");
        medio_5.Add("00111111");
        Linguagem linguagem_medio_5 = new Linguagem(medio_5,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\medio_5.jpg");
    
        linguagens_medio.Add(linguagem_medio_1);
        linguagens_medio.Add(linguagem_medio_2);
        linguagens_medio.Add(linguagem_medio_3);
        linguagens_medio.Add(linguagem_medio_4);
        linguagens_medio.Add(linguagem_medio_5);
    }

    private void InserirLinguagensDificeis() {
        List<string> dificil_1 = new List<string>();
        dificil_1.Add("ab");
        dificil_1.Add("c");
        dificil_1.Add("ababc");
        dificil_1.Add("ababccc");
        dificil_1.Add("abccc");
        dificil_1.Add("ababab");
        dificil_1.Add("ababcccc");
        dificil_1.Add("abcc");
        Linguagem linguagem_dificil_1 = new Linguagem(dificil_1,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\dificil_1.jpg");

        List<string> dificil_2 = new List<string>();
        dificil_2.Add("abcd");
        dificil_2.Add("ababcd");
        dificil_2.Add("ababcdcd");
        dificil_2.Add("cd");
        dificil_2.Add("abcdcd");
        dificil_2.Add("abcdcdcd");
        dificil_2.Add("ababcdcdcd");
        dificil_2.Add("abababcd");
        Linguagem linguagem_dificil_2 = new Linguagem(dificil_2,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\dificil_2.jpg");

        List<string> dificil_3 = new List<string>();
        dificil_3.Add("ababababccc");
        dificil_3.Add("ababc");
        dificil_3.Add("abababc");
        dificil_3.Add("ababcccc");
        dificil_3.Add("ababcc");
        dificil_3.Add("abccccc");
        dificil_3.Add("ababccc");
        dificil_3.Add("abababcccc");
        Linguagem linguagem_dificil_3 = new Linguagem(dificil_3,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\dificil_3.jpg");

        List<string> dificil_4 = new List<string>();
        dificil_4.Add("bb");
        dificil_4.Add("babb");
        dificil_4.Add("bababb");
        dificil_4.Add("babababb");
        dificil_4.Add("bababababb");
        dificil_4.Add("babababababb");
        dificil_4.Add("babababababababb");
        dificil_4.Add("bababababababababb");
        Linguagem linguagem_dificil_4 = new Linguagem(dificil_4,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\dificil_4.jpg");

        List<string> dificil_5 = new List<string>();
        dificil_5.Add("baba");
        dificil_5.Add("ba");
        dificil_5.Add("bababa");
        dificil_5.Add("babababa");
        dificil_5.Add("bababababa");
        dificil_5.Add("babababababa");
        dificil_5.Add("bababababababa");
        dificil_5.Add("babababababababa");
        Linguagem linguagem_dificil_5 = new Linguagem(dificil_5,@"C:\Users\renan\Desktop\Linguagens\Linguagens_AD\Fotos_AD\dificil_5.jpg");
    
        linguagens_dificil.Add(linguagem_dificil_1);
        linguagens_dificil.Add(linguagem_dificil_2);
        linguagens_dificil.Add(linguagem_dificil_3);
        linguagens_dificil.Add(linguagem_dificil_4);
        linguagens_dificil.Add(linguagem_dificil_5);
    }

    public Linguagem Random_Linguagem(List<Linguagem> linguagens) {
        //int valor = UnityEngine.Random.Range(0,linguagens.Count);
        int valor = UnityEngine.Random.Range(0,linguagens.Count+1);
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
