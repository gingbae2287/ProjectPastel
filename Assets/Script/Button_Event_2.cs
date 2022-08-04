using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Event_2 : MonoBehaviour{

    public GameObject Ball; //프리펩 변수
    GameObject player;
    GameObject shootPoint;

    Animator animator;
    Vector3 shootingDegree;
    bool isPlayerEnter;
    void Awake(){
        player=GameObject.FindGameObjectWithTag("Player");
        shootPoint=GameObject.FindGameObjectWithTag("Ballshootpoint");
        //animator=GetComponent<Animator>();
        isPlayerEnter=false;
        //shootingDegree=transform.position;
    }

    void Update(){
        if(isPlayerEnter && Input.GetButtonDown("Action")){
            //animator.SetTrigger("PushButton");
            //Invoke("BallShoot", 1.5f);  //딜레이함수
            BallShoot();
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject==player){
            isPlayerEnter=true;

        }

    }
    void OnTriggerExit(Collider other){
        if(other.gameObject==player){
            isPlayerEnter=false;
        }

    }

    void BallShoot(){
        //Instantiate(Ball, shootPoint.transform.position, shootPoint.transform.rotation);
        GameObject instantItem=(GameObject)Instantiate(Ball, shootPoint.transform.position, shootPoint.transform.rotation);
        Rigidbody rigidbody2=instantItem.GetComponent<Rigidbody>();
        shootingDegree=player.transform.position-shootPoint.transform.position;
        shootingDegree.y=10f;
        /*shootingDegree.x*=0.3f;
        shootingDegree.z*=0.3f;*/
        rigidbody2.AddForce(shootingDegree, ForceMode.Impulse);
    }
}