using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A TORRE NÃO PODE TER COLLIDER SE NÃO, NÃO FUNCIONA
public class TorreIA : MonoBehaviour
{   

    public float Range;
    public Transform Target;
    public string TextoAutomato;
    public bool Detected;

    Vector2 Direction;


    // Start is called before the first frame update
    void Awake() {
        //this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    void Start()
    {
       Range = 4f;
       this.gameObject.transform.GetChild(0).gameObject.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);
        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {   
                print("entrou no if rayInfo.collider.gameObject.tag");
                if (Detected == false)
                {   
                    print("detectado");
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {   
                    print("saiu do detectado");
                    Detected = false;
                }
            }
        }
        

        Debug.Log(TextoAutomato);
    }
    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position,Range);
    }

    public void InsereTextoAutomato() {
        /*TextoAutomato = 
        this.gameObject.transform.GetChild(0)
        .gameObject.transform.GetChild(0)
        .gameObject.transform.GetChild(2)
        .gameObject.GetComponent<Text>().text;
        */
        TextoAutomato = 
        this.gameObject.transform.GetChild(0)
        .gameObject.transform.GetChild(0)
        .gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text; 
    }

    void OnMouseDown() {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void EscondeCanvas() {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    } 
}
