using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Destroy(this.gameObject,2);
    }


    void OnCollisionEnter2D(Collision2D Col) {
        //aqui pode remover a vida do objeto
        //Debug.Log(Col.gameObject.name);
        if( Col.gameObject.tag == "Player") {
            //GameObject Alvo = Col.gameObject;
            if(Col.gameObject.transform.GetComponent<Monstro>()){
                Col.gameObject.transform.GetComponent<Monstro>().TiraVida(20);
            }
            if(Col.gameObject.transform.GetComponent<Civil>()){
                Col.gameObject.transform.GetComponent<Civil>().TiraVida(20);
            }
            Destroy(this.gameObject,0);
        }

        Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), Col.gameObject.GetComponent<Collider2D>());
    }
}
