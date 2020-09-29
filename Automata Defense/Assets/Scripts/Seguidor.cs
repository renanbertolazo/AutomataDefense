using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Seguidor : MonoBehaviour
{
    private GameObject player;
    //public UnityEngine.AI.NavMeshAgent navMesh;

    void Awake()
    {
        //navMesh.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {   
        //UnityEngine.AI.NavMeshAgent.Warp(player.transform.position);
        //navMesh.destination = player.transform.position;
        //navMesh.SetDestination = (player.transform.position);
    }
}
