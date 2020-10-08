using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civil : MonoBehaviour
{   

    public float speed;
    public double vida = 100;
    public GameObject TORRE1;
    // Start is called before the first frame update
    void Awake()
    {
        //transform.tag = "Player";
        //print ("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //print (vida);
        //Destroy(GameObject);
        //print (transform.position);
        /*if (vida == 0) {
            Destroy(gameObject,1);
        }
        vida += 0.01;*/
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * 2;
    }

    void OnMouseDown(){

        Instantiate(TORRE1,transform.position,transform.rotation);

    }

    public void setVida(int vida1){

        vida = vida1;
    }
}
