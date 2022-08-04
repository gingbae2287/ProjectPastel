using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingObj : MonoBehaviour
{

    int dir=1;
    public int speed=15;
    float height;
    public float Height{get{return height;}}
    int maxY;
    bool isGaming;
    Vector3 maxPosition;
    Vector3 minPosition;
    //[SerializeField] CookingObj cookObj;

    void Start(){
        isGaming=false;
        height=GetComponent<RectTransform>().rect.height;
        maxY=(int)(transform.parent.gameObject.GetComponent<RectTransform>().rect.height-height)/2;

        maxPosition=transform.position;
        minPosition=maxPosition;
        maxPosition.y+=maxY;
        minPosition.y-=maxY;

    }

    private void Update() {
        if(isGaming){
            ChangeDir();
            Move();
        }
    }

    public void Init(){
        isGaming=false;
        
    }
    public void GameStart(){
        isGaming=true;
        transform.localPosition=Vector3.zero;

    }
    public void GameStop(){
        isGaming=false;
        transform.localPosition=Vector3.zero;
    }
    void Move(){
        if(transform.localPosition.y<-maxY) {
            transform.position=minPosition;
        }
        else if(transform.localPosition.y>maxY) {
            transform.position=maxPosition;
        }
        transform.Translate(speed*Vector3.down*Time.deltaTime*dir);
    }
    void ChangeDir(){
        if(Input.GetMouseButtonDown(0)){
            dir=1;
        }
        else if(Input.GetMouseButtonUp(0)){
            dir=-1;
        }
    }


}