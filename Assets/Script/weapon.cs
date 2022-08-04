using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject playerEquipPoint;
    human playerLogic;

    Vector3 forceDirection;
    bool isPlayerEnter;

    void Awake() {
        player=GameObject.FindGameObjectWithTag("Player");
        playerEquipPoint=GameObject.FindGameObjectWithTag("EquipPoint");
        playerLogic=player.GetComponent<human>();
    }
    void Start()
    {
        
    }

    void OnTriggerEnter( Collider other){
        if(other.gameObject==player){
            isPlayerEnter=true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject==player){
            isPlayerEnter=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Action")&&isPlayerEnter){
            transform.SetParent(playerEquipPoint.transform);
            transform.localPosition=Vector3.zero;
            transform.rotation=new Quaternion(0,0,0,0);

            playerLogic.Pickup(gameObject);

            isPlayerEnter=false;
        }
    }
}
