using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Monstro : MonoBehaviour
{
    private GameObject player;
    //public UnityEngine.AI.NavMeshAgent navMesh;
    //public TMP_Text texto;

    public GameObject children;
    void Awake()
    {
        //navMesh.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        //children.transform.GetChild(0).gameObject.SetActive(false);
        //Debug.Log(children.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text);
        //Debug.Log(children.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text);
        //navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Move();
        //Debug.Log(children.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text);
        //UnityEngine.AI.NavMeshAgent.Warp(player.transform.position);
        //navMesh.destination = player.transform.position;
        //navMesh.SetDestination = (player.transform.position);
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * 2;
    }
}
