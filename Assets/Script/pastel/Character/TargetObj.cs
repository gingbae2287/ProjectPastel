using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObj: MonoBehaviour{
    Vector3 playerPosition;
    Vector3 destination;
    Vector3 dir;
    [SerializeField] char_dummy Character;
    Item item;
    public ItemProperty prop{get; private set;}
    float speed;
    public bool action{get; private set;}
    float range;


    ////
    BoxCollider col;    //action 중에만 트리거 가능

    void Start(){
        playerPosition=transform.localPosition;
        speed=50;
        range=2;
        action=false;
        col=GetComponent<BoxCollider>();
        col.isTrigger=false;
    }

    void Update(){
        if(action){
            transform.position=Vector3.MoveTowards(transform.position, destination, speed*Time.deltaTime);
            Vector3 tmp=transform.position-destination;
            if(tmp.sqrMagnitude<0.1) {
                action=false;
                col.isTrigger=false;
                transform.localPosition=playerPosition;
                Character.ActionFinish();
            }
            
        }
    }
    public void Action(Vector3 direction){
        if(action) return;
        col.isTrigger=true;
        action=true;
        dir=direction;
        destination=transform.position+dir*range;
        item=PlayerManager.Instance.currentSlot.item;
        prop=item.property;
    }

    void OnTriggerEnter(Collider other) {

    }
}