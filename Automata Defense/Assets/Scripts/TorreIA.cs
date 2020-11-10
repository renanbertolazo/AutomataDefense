using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A TORRE NÃO PODE TER COLLIDER SE NÃO, NÃO FUNCIONA
public class TorreIA : MonoBehaviour {   

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
    public LayerMask LayerAlvo;

    // Start is called before the first frame update
    void Awake() {
        //this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //Shootpoint.transform.position = this.transform.position;
    }
    void Start() {

       this.gameObject.transform.GetChild(0).gameObject.SetActive(true); 
       
    }

    // Update is called once per frame
    void Update() {
        //IA();
        IA2();
    }


    private void IA2() {
        
        //RaycastHit2D rayInfo;
        //print(Target);
        Physics2D.queriesStartInColliders = true;

        if(!Target) {
            RaycastHit2D[] rayInfo = Physics2D.CircleCastAll(transform.position, Radius, Direction, Range, LayerAlvo);
            foreach(RaycastHit2D hit in rayInfo) {
                if(hit.collider.gameObject.transform.name == "Monstro" || hit.collider.gameObject.transform.name == "Monstro(Clone)") {
                    if(hit.collider.gameObject.transform.GetComponent<Monstro>().palavra == "Monstro") {
                    print(hit.collider.gameObject.transform.position);
                    Target = hit.collider.gameObject.transform;
                    break;
                    }
                }
            }
        }

        if(Target) {
            Vector2 targetPos = Target.position;
            Direction = targetPos - (Vector2)transform.position;
            float dist = Vector3.Distance(targetPos, transform.position);
            if(Time.time > nextTimeToFire && dist < 3f) {
                nextTimeToFire = Time.time + 1 / FireRate;
                Atira();
                //print("Distance to other: " + dist);
            }
            if(dist > 3f) Target = null;
        }

    }
        
    
    public void IA() {
        
        //os tiros nao ocorrem pois está apenas reconhecendo as torres
        //usar para retornar um vetor de alvos
        RaycastHit2D rayInfo;
        //rayInfo = Physics2D.queriesStartInColliders(true);
        Physics2D.queriesStartInColliders = true;
        // colocar em outra layermask dai nao detecta
        rayInfo = Physics2D.CircleCast(transform.position, Radius, Direction, Range, LayerAlvo);
        if (rayInfo) {   
            Debug.Log(rayInfo.collider.gameObject.name);
            if(rayInfo.collider.gameObject.tag == "Player") {   
                Target = rayInfo.collider.gameObject.transform;
                Vector2 targetPos = Target.position;
                Direction = targetPos - (Vector2)transform.position;

                float dist = Vector3.Distance(targetPos, transform.position);

                if(Time.time > nextTimeToFire && dist < 3f) {
                    nextTimeToFire = Time.time + 1 / FireRate;
                    Atira();
                    print("Distance to other: " + dist);
                }
                //print(rayInfo.collider.gameObject.GetComponent<Civil>().palavra);
                //print("entrou no if rayInfo.collider.gameObject.tag");
                if (Detected == false) {   
                    //print("detectado");
                    Detected = true;
                }
            }

            Detected = false;
        }
        
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
