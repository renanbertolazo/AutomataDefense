using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BuildingManager : MonoBehaviour {   
    //no Serializa apenas a class e o editor pode ver a variavel
    [SerializeField] private GameObject Torre;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start() {
        
        mainCamera = Camera.main;
        //Debug.Log("Oie");

    }

    // Update is called once per frame
    void Update() {   
            //TORRE1.position = GetMouseWorldPosition();
            /*if(Input.GetMouseButtonDown(0)) {
                Instantiate(TORRE1, GetMouseWorldPosition(), Quaternion.identity);
            }
            if(Input.GetKeyDown(KeyCode.T)){
                Instantiate(Torre, GetMouseWorldPosition(), Quaternion.identity);
            }
            */
            CriaTorre();
    
    }

    public void CriaTorre() {
        if(Input.GetKeyDown(KeyCode.T)){
                if(ValidaPosicao()) {
                    Instantiate(Torre, GetMouseWorldPosition(), Quaternion.identity);
                    AstarPath.active.Scan();   
                }
                //Instantiate(Torre, GetMouseWorldPosition(), Quaternion.identity);
                //AstarPath.active.Scan();
            }
    }

    private bool ValidaPosicao() {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if(mouseWorldPosition.x > 2.5 || mouseWorldPosition.x < -8.5) return false;
        if(mouseWorldPosition.y > 4.5 || mouseWorldPosition.y < -4.5) return false;
        return true;
    }

    //pega a posicao do mouse e converte para, a posicao do mundo do jogo 
    //Camera.main se deve ao fato da camera com tag "main"
    //Debug.Log(Input.mousePosition);
    //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    private Vector3 GetMouseWorldPosition(){
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
}
