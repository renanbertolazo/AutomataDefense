using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TorreInput : MonoBehaviour
{   

    public Text texto;
    public GameObject EntradaAutomato;
    public GameObject TextoAutomato;
    // Start is called before the first frame update
    void Start()
    {   
        //Vector3 pos = new Vector3();
        //Instantiate(EntradaAutomato,transform.position,transform.rotation);
        //EntradaAutomato.SetActive(true);
        
        //texto = TextoAutomato.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        //TextoAutomato.GetComponent<Text>();
        //Debug.Log(TextoAutomato.GetComponent<Text>());
        texto = TextoAutomato.GetComponent<Text>();
        string opa = texto.ToString();
        Debug.Log(opa);

    }
}
