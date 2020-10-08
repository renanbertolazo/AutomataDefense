using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A TORRE NÃO PODE TER COLLIDER SE NÃO, NÃO FUNCIONA
public class TorreIA : MonoBehaviour
{   

    public float Range;
    public Transform Target;

    public bool Detected;

    Vector2 Direction;


    // Start is called before the first frame update
    void Start()
    {
       Range = 2f; 
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
    }
    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position,Range);
    } 
}
