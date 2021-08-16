using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour {   
    public GameObject Civil;

    public GameObject Monstro;

    /*
    public void InstanciaMonstro() {
        Instantiate(Monstro, this.transform.position, Quaternion.identity);
    }

    public void InstanciaCivil() {
        Instantiate(Civil, this.transform.position, Quaternion.identity);
    }*/
    private int RandomValue(int ini, int fim) {
        return UnityEngine.Random.RandomRange(ini, fim);
    }

    public void InstanciaMonstro() {
        Vector2 pos = this.transform.position;
        int aux = RandomValue(1, 4);
        if(aux == 1) {
            pos.y = pos.y + 3;
            Instantiate(Monstro, pos, Quaternion.identity);
        }
        if(aux == 2) {
            Instantiate(Monstro, pos, Quaternion.identity);
        }
        if(aux == 3) {
            pos.y = pos.y - 3;
            Instantiate(Monstro, pos, Quaternion.identity);
        }
        //print("oi");
        //print(pos);
        //print(aux);
        //Instantiate(Monstro, this.transform.position, Quaternion.identity);
    }

    public void InstanciaCivil() {
        Vector2 pos = this.transform.position;
        int aux = RandomValue(1, 4);
        if(aux == 1) {
            pos.y = pos.y + 2;
            Instantiate(Civil, this.transform.position, Quaternion.identity);
        }
        if(aux == 2) {
            Instantiate(Civil, this.transform.position, Quaternion.identity);
        }
        if(aux == 3) {
            pos.y = pos.y - 2;
            Instantiate(Civil, this.transform.position, Quaternion.identity);
        }
        //print("oi");
        //print(pos);
        //print(aux);
        //Instantiate(Civil, this.transform.position, Quaternion.identity);
    }
}
