using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.IO;
using System.Linq;

class Transicao {
    public string destino { get; set; }
    public char simbolo { get; set; }

    public Transicao(string dest, char simb) {
        destino = dest;
        simbolo = simb;
    }
}

class Estado {
    public string nome { get; set; }
    public List<Transicao> transicao { get; set; }

    public Estado(string nomeestado, List<Transicao> transicoes) {
        nome = nomeestado;
        transicao = transicoes;
    }
    public Estado() {
        transicao = new List<Transicao>();
    }
}

class Automato : MonoBehaviour {
    public List<Estado> estado { get; set; }
    public List<string> final { get; set; }
    public string inicial { get; set; }

    public Automato(List<Estado> estados, List<string> finais, string estadoinicial) {
        estado = estados;
        final = finais;
        inicial = estadoinicial;
    }

    public Automato() {
        estado = new List<Estado>();
        inicial = null;
        final = new List<string>();
    }
    
    public void Clear() {
        estado = new List<Estado>();
        inicial = null;
        final = new List<string>();
    }

    public Estado BuscaEstado(string nome) {
        Estado res = new Estado();

        foreach (Estado item in estado) {
            if(item.nome == nome) res = item;
        };
        return res;
    }

    public bool Reconhecedor(string palavra) {
        Estado estado_atual = BuscaEstado(this.inicial);
        bool pertence = false;
        bool palavra_lida = false;
        //Console.WriteLine(estado_atual.nome);
        //print("Tamanho:"+this.inicial.Length+ "Nome:"+this.inicial.Length);
        //print(estado_atual.nome);
        foreach (var letra in palavra) {
            //print(letra);
            bool transitou = false;
            Estado estado_transicao_vazia = new Estado();
            bool transicao_vazia = false;
            foreach (Transicao transicao in estado_atual.transicao) {
                //print("ver transições");
                if(transicao.simbolo == '@') {
                    estado_transicao_vazia = BuscaEstado(transicao.destino);
                    transicao_vazia = true;
                };
                if(transicao.simbolo == letra) {
                    estado_atual = BuscaEstado(transicao.destino);
                    transitou = true;
                    //Console.WriteLine(estado_atual.nome);
                    //print(estado_atual.nome);
                };   
            };
            //caso transição seja vazia
            while(transitou == false && transicao_vazia == true) {
                transicao_vazia = false;
                estado_atual = estado_transicao_vazia;
                foreach (Transicao transicao in estado_atual.transicao) {
                    if(transicao.simbolo == '@') {
                        estado_transicao_vazia = BuscaEstado(transicao.destino);
                        transicao_vazia = true;
                    };
                    if(transicao.simbolo == letra) {
                        estado_atual = BuscaEstado(transicao.destino);
                        transitou = true;
                    };   
                };
                //Console.WriteLine(estado_atual.nome);
                //transitou = true;
            };
            if(transitou == true) palavra_lida = true;
            if(transitou == false) {
                palavra_lida = false; 
                break;
            };
            //Console.WriteLine(estado_atual.nome);
        }
        if (palavra_lida == false) return pertence;

        foreach (string item in this.final) {
            if(item == estado_atual.nome) {
            pertence = true;
            };
        };
        return pertence;
    }

    public void Carrega_Arquivo(string[] path) {
        if (path == null) {
            print("nao existe"); 
            return;
        }
        path = path.Where(w => !string.IsNullOrEmpty(w)).ToArray();
        
        //foreach(string f in path) print(f);

        string inicial = null;
        string s = path[0];
        bool x = false;
        foreach (var letra in s) {
            if(x == true) {
                //if(letra == ' ') print("vazio");
                //if(letra == '\r') print("opa");
                if((letra != ' ') && !Equals(letra, "\0") && (letra != '\r')) {
                    inicial += letra;
                    //print(letra);
                }
            }
            if(letra == '=') x = true; 
        }

        //byte[] asciiBytes = Encoding.ASCII.GetBytes(inicial);
        //foreach(byte b in asciiBytes) print(b);

        //inicial = inicial.Replace(" ","");
        //inicial = inicial.Replace(" ","");
        //inicial = inicial.Substring(0,inicial.Length);
        this.inicial = inicial;
        //print(this.inicial.Length);
        //print("inicial:"+ inicial+ "tamanho:"+ inicial.Length);
        List<string> finais = new List<string>();
        s = path[1];
        string final = null;
        x = false;
        int i = 0;
        for (i = 0; s[i] != '{'; i++);
        i++;
        while(s[i] != '}') {
            do {
                if((s[i] != ' ') && !Equals(s[i], "\0") && (s[i] != '\r')){
                    final += s[i];
                }
                //final += s[i];
                i++;
            } while (s[i] != ',' && s[i] != '}');
            //final = final.Replace(",","");
            //final = final.Replace(" ","");
            finais.Add(final);
            //Console.WriteLine(final);
            //Console.WriteLine(final.Length);
            this.final.Add(final);
            final = null;
        }
        
        //foreach(string f in finais) print("final: "+f+" tamanho:"+f.Length);
        
        int k = 2;
        while(k < path.Length) {
            s = path[k];
            
            k++;
            string estado_atual = null;
            string estado_chegada = null;
            string simbolo = null;
            //print(k);
            //print(s);
            i = 0;
            while(s[i] != '(') {
                //print(s[i]);
                i++;            
            } 
            i++;
            while(s[i] != ',') {
                if((s[i] != ' ')){
                    estado_atual+= s[i];
                }
                //estado_atual+= s[i];
                i++;
            }
            i++;
            while(s[i] != ')') {
                if((s[i] != ' ')){
                    simbolo+= s[i];
                }
                //simbolo+= s[i];
                i++;
            }
            i++;
            while(s[i] != '=') i++;
            i++;
            while(i < s.Length) {
                if((s[i] != ' ') && !Equals(s[i], "\0") && (s[i] != '\r')){
                    estado_chegada += s[i];
                }
                i++;
            }
            
            //estado_atual = estado_atual.Replace(",","");
            //estado_atual = estado_atual.Replace(" ","");
            //simbolo = simbolo.Replace(",","");
            //simbolo = simbolo.Replace(" ","");
            //estado_chegada = estado_chegada.Replace(",","");
            //estado_chegada = estado_chegada.Replace(" ","");
            //estado_chegada = estado_chegada.Substring(0,estado_chegada.Length);

            Transicao trans = new Transicao(estado_chegada, Convert.ToChar(simbolo));

            if(this.estado == null) {
                Estado estado_x = new Estado();
                estado_x.nome = estado_atual;
                estado_x.transicao.Add(trans);
                this.estado.Add(estado_x);
            } else {
                bool adicionou_atual = false;
                bool adicionou_chegada = false;
                foreach (Estado item in this.estado) {
                    if(Equals(item.nome, estado_atual)) {
                        item.transicao.Add(trans);
                        adicionou_atual = true;
                    }
                    if(Equals(item.nome, estado_chegada)) {
                        item.transicao.Add(trans);
                        adicionou_chegada = true;
                    }
                }
                if(adicionou_atual == false) {
                    Estado estado_x = new Estado();
                    estado_x.nome = estado_atual;
                    estado_x.transicao.Add(trans);
                    this.estado.Add(estado_x);
                }
                if(adicionou_chegada == false) {
                    Estado estado_x = new Estado();
                    estado_x.nome = estado_chegada;
                    estado_x.transicao.Add(trans);
                    this.estado.Add(estado_x);
                }
            }
            //Console.WriteLine(estado_atual);
            //Console.WriteLine(simbolo);
            //Console.WriteLine(estado_chegada);
        }
    }

    public bool isDeterministico() {
        bool retorno = true;
        foreach (Estado item in this.estado) {
            List<string> simbolos = new List<string>();
            foreach (Transicao trans in item.transicao) {
                simbolos.Add(Convert.ToString(trans.simbolo));
            }

            if(simbolos.Count != simbolos.Distinct().Count()) {
                retorno = false;
            }
        }

        return retorno;
    }
    public void printa() {
        print("Estado inicial:" +this.inicial+" tamanho: "+this.inicial.Length);
        foreach (string final in this.final) {
            print("Estado final:" +final+" tamanho: "+final.Length);
        }

        foreach (Estado item in this.estado) {
            print("Estado nome:" +item.nome+" tamanho: "+item.nome.Length);
            foreach (Transicao trans in item.transicao) {
                print("Transicao :" +trans.destino+" tamanho: "+trans.destino.Length+","+trans.simbolo);
            }
        }
    }
}
