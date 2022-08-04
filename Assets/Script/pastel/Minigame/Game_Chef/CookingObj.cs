using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingObj : MonoBehaviour
{

    public float speed=20f;
    int maxY;
    float height;
    //int dest;
    float overlapSize;
    int craftObjSize;
    float timecount;
    bool moveReady;
    bool isMove;
    bool isGaming;
    Vector3 dest;
    Vector3 startPosition;

    [SerializeField] CraftingObj craftObj;
    [SerializeField] UI_CraftingGauge UIgauge;
    int gauge;
    void Start(){
        //초기화 변수
        startPosition=transform.position;
        dest=Vector3.zero;
        timecount=0;
        moveReady=false;
        isMove=false;
        UIgauge.MaxGauge=100;
        gauge=0;
        UIgauge.GaugeUpdate(gauge);
        /////
        isGaming=false;
        height=GetComponent<RectTransform>().rect.height;
        maxY=(int)(transform.parent.gameObject.GetComponent<RectTransform>().rect.height-height)/2;
        //overlapSize=(craftObj.Height-height)/2;
        //여기서 craftObj.Height 을 받아오니 0으로 적용됨. gameStart시 적용해야겠다.
    }
    private void Update() {
        if(isGaming){
            GameAction();
            Move();
        }
    }

    public void Init(){
        isGaming=false;
        timecount=0;
        moveReady=false;
        isMove=false;
        UIgauge.MaxGauge=100;
        gauge=0;
        UIgauge.GaugeUpdate(gauge);
    }

    public void GameStart(){
        isGaming=true;
        //초기화 변수
        craftObjSize=(int)(craftObj.Height);
        overlapSize=(craftObjSize-height)/2;
        transform.localPosition=Vector3.zero;
        //dest=Vector3.zero;
        MoveRandom();
        
        timecount=0;
        moveReady=false;
        isMove=false;
        UIgauge.MaxGauge=100;
        gauge=0;
        UIgauge.GaugeUpdate(gauge);
        
        /////
    }
    public void GameStop(){
        isGaming=false;
        transform.localPosition=Vector3.zero;
    }
    //게임시작시 코루틴
    /*IEnumerator CheckAction(){
        while(true){
            if(CheckOverlap()){
                //겹쳐졌을경우
                //1초후 게이지 4%증가
                //2초후 움직임
                yield return new WaitForSeconds(1f);
                if(CheckOverlap()){
                    //게이지 4프로 증가
                }

            }
            else{

            }
        }
    }*/
    void GameAction(){
        /*Debug.Log("TimeScale="+Time.timeScale);
        Debug.Log("deltaTime="+Time.deltaTime);
        Debug.Log("timecounte="+timecount);
        timecount+=Time.deltaTime;*/
        if(CheckOverlap()){
            timecount+=Time.deltaTime;
            
        }
        else timecount=0;
        if(timecount>=1){
            if(isMove){

            }
            else if(!moveReady){
            //1초 머물시 게이지 증가
            moveReady=true;
            }
            else{
                moveReady=false;
                MoveRandom();
            }
            //게이지 증가 함수 (공통)
            timecount-=1;
            gauge+=4;
            UIgauge.GaugeUpdate(gauge);
        }
    }

    void MoveRandom(){
        int y=Random.Range(craftObjSize,maxY*2-craftObjSize)+(int)(transform.localPosition.y);
        if(y>=maxY) y-=(maxY*2);
        dest=startPosition;
        //dest.y=Random.Range(0,maxY*2)+(int)(transform.localPosition.y);
        //if(dest.y>=maxY) dest.y-=(maxY*2);
        dest.y+=y;
        isMove=true;

    }
    void Move(){
        if(!isMove) return;
        transform.position=Vector3.MoveTowards(transform.position,dest,speed*Time.deltaTime);
        if(transform.position==dest){
            isMove=false;
        }

    }
        //제작 오브젝트와 겹치는지 판단.
    bool CheckOverlap(){
        //abs(제작 y-요리 y) < (제작height - this.height)/2
        //Debug.Log("craftObj.y="+craftObj.transform.position.y);
        //Debug.Log("cookObj.y="+transform.position.y);
        //Debug.Log(overlapSize);
        if(Mathf.Abs(craftObj.transform.position.y-transform.position.y) < overlapSize) 
        {
            //Debug.Log(overlapSize);
            return true;
        }
        else return false;
    }

    
}