using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Civil : MonoBehaviour
{   
    public GameObject children;
    public float speed;
    public double vida = 100;

    public string palavra;
    //public GameObject Torre;
    // Start is called before the first frame update
    void Awake()
    {
        //transform.tag = "Player";
        //print ("Hello World!");
        palavra = "hello men";
        //palavra = children.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
        children.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(palavra);
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

    /*
    void OnMouseDown(){

        Instantiate(Torre,transform.position,transform.rotation);

    }
    */
    public void setVida(int valor){

        vida = valor;
    }
}
