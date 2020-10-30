using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{   
    public GameObject Monstro;
    public void InstanciaMonstro() {
        Instantiate(Monstro, this.transform.position, Quaternion.identity);
    }
}
