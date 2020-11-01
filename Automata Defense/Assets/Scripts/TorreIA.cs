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
    public float Radius;
    Vector2 Direction;

    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;

    //Máscara a ser ignorada
    public LayerMask IgnoreMe;

    // Start is called before the first frame update
    void Awake() {
        //this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //Shootpoint.transform.position = this.transform.position;
    }
    void Start()
    {
       //Range = 4f;
       //Radius = 2f;
       this.gameObject.transform.GetChild(0).gameObject.SetActive(true); 
       //IgnoreMe.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        IA();
    }

    public void IA() {
        
        //os tiros nao ocorrem pois está apenas reconhecendo as torres
        //usar para retornar um vetor de alvos
        RaycastHit2D rayInfo;
        //rayInfo = Physics2D.queriesStartInColliders(true);
        Physics2D.queriesStartInColliders = true;
        // colocar em outra layermask dai nao detecta
        rayInfo = Physics2D.CircleCast(transform.position,Radius,Direction,Range, IgnoreMe);
        if (rayInfo)
        {   
            Debug.Log(rayInfo.collider.gameObject.name);
            if(rayInfo.collider.gameObject.tag == "Player")
            {   
                Target = rayInfo.collider.gameObject.transform;
                Vector2 targetPos = Target.position;
                Direction = targetPos - (Vector2)transform.position;
                
                //Debug.Log(Direction);
                //Atira();
                if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                Atira();
            }
                //print(rayInfo.collider.gameObject.GetComponent<Civil>().palavra);
                //print("entrou no if rayInfo.collider.gameObject.tag");
                if (Detected == false)
                {   
                    //print("detectado");
                    Detected = true;
                }
            }

            Detected = false;
            /*else
            {
                if (Detected == true)
                {   
                    //print("saiu do detectado");
                    Detected = false;
                }
            }
            */
        //this.transform.up = Direction;
        }
        /*
        if (Detected)
        {
            transform.up = Direction;
        }
        */
    }

    void RotateToEnemy() {
        Quaternion rotation = Quaternion.LookRotation
        (Target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        
        /*
        Quaternion rotation = Quaternion.LookRotation
        (Target.transform.position - this.gameObject.transform.GetChild(1).gameObject.transform.position, transform.TransformDirection(Vector3.up));
        this.gameObject.transform.GetChild(1).gameObject.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        */
    }

    void Atira() {
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    void OnDrawGizmosSelected() {
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
        this.gameObject.transform.GetChild(0)
        .gameObject.transform.GetChild(0)
        .gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = TextoAutomato;

        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //Destroy(this.gameObject,0);
    }

    public void EscondeCanvas() {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    } 

    public void DestroiTorre() {
        Destroy(this.gameObject,0);
        AstarPath.active.Scan();
    }
}
