using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;

    public float offsetX=3.5f;
    public float offsetY=5f;
    public float offsetZ=-4.5f;
    public float followSpeed=5f;
    Vector3 offset;
    private float camera_distanse=1f;

    float rotateX;
    float rotateY;
    //public float camera_movement=1f;

    Vector3 cameraPosition;
    void Start()
    {
        cameraPosition.x=player.transform.position.x+(offsetX*camera_distanse);
        cameraPosition.y=player.transform.position.y+(offsetY*camera_distanse);
        cameraPosition.z=player.transform.position.z+(offsetZ*camera_distanse);

        transform.position=cameraPosition; 
        
    }

    // Update is called once per frame
    void Update()
    {
        ScrollView();
    }

    void LateUpdate(){
        //게임상의 모든 update로직 마친후 마지막 update 주로 카메라이동

        MoveCamera();
       // RotateCamera();

        //더 부드러운 카메라
        //transform.position=Vector3.Lerp(transform.position, cameraPosition,followSpeed*Time.deltaTime);
    }

    void ScrollView(){
        if(Input.GetAxis("Mouse ScrollWheel")>0){
            if(camera_distanse>0.2) camera_distanse-=0.1f;
        }
        if(Input.GetAxis("Mouse ScrollWheel")<0){
            if(camera_distanse<2) camera_distanse+=0.1f;
        }
    }

    void RotateCamera(){
        if(Input.GetMouseButton(0)){
            rotateX=Input.GetAxis("Mouse X")* Time.deltaTime*100;
            rotateY=Input.GetAxis("Mouse Y")*Time.deltaTime*100;
            Debug.Log("마우스회전");
            transform.RotateAround(player.transform.position, Vector3.up, rotateX);
            transform.RotateAround(player.transform.position,new Vector3(1,0,1), -rotateY);

            
        }
        offset=transform.position-player.transform.position;
        offset.Normalize();

        transform.position=player.transform.position + offset*camera_distanse;
        transform.LookAt(player.transform.position);
        
    }

    void MoveCamera(){
        cameraPosition.x=player.transform.position.x+(offsetX*camera_distanse);
        cameraPosition.y=player.transform.position.y+(offsetY*camera_distanse);
        cameraPosition.z=player.transform.position.z+(offsetZ*camera_distanse);

        transform.position=cameraPosition; 
    }
}
