using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavScript : MonoBehaviour
{
    GameObject player;
    Animator animator;
    UnityEngine.AI.NavMeshAgent nav;
    bool closed_to_player;
    bool moving=true;

    void Awake(){
        player=GameObject.FindGameObjectWithTag("Player");
        //animator=GetComponent<Animator>();
        nav=GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)  follow();
        
    }

    void OnTriggerStay(Collider other){
        if (other.gameObject.tag=="Player"){
            closed_to_player=true;

        }

    }
    void OnTriggerExit(Collider other){
        if (other.gameObject.tag=="Player"){
            closed_to_player=false;
            moving=true;

        }

    }

    void follow(){
        if(!closed_to_player) {
            nav.SetDestination(player.transform.position);
        }
        else  {
            nav.SetDestination(transform.position);
            moving=false;
        }

    }
}
