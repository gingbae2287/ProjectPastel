using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Event : MonoBehaviour{
    GameObject player;
    void Awake(){
        player=GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject==player){
            Vector3 originPoint=new Vector3();
            originPoint.x=0f;
            originPoint.y=3f;
            originPoint.z=0f;

            player.transform.position=originPoint;
            ////
            human.HP-=10;
        }

    }
    void OnTriggerExit(Collider other){

    }
}