using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{   
    public GameObject Civil;

    public GameObject Monstro;
    public void InstanciaMonstro() {
        Instantiate(Monstro, this.transform.position, Quaternion.identity);
    }

    public void InstanciaCivil() {
        Instantiate(Civil, this.transform.position, Quaternion.identity);
    }
}
