using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D Col) {
        //aqui pode remover a vida do objeto
        Debug.Log(Col.gameObject.name);
        if( Col.gameObject.tag == "Player") {
        Col.gameObject.transform.GetComponent<Civil>().TiraVida(20);
        Destroy(this.gameObject,0);
        }

        Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), Col.gameObject.GetComponent<Collider2D>());
    }
}
