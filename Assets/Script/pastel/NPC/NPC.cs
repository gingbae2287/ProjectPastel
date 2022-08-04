using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    bool NPCon;
    public UI_NPCDialog UI_NPCDialog;
    
    //public NPCDialog
    public string[] chat={"안녕.","이름이뭐니?","난 바나나맨이야"};

    //public string[,] selectDialog={};
    int text_count;
    public string npc_name="";

    public TextMesh Name3d;
    Vector3 name_ui_position;
    //TextMesh name_ui;
    
    [SerializeField] int NPCNum;    //상점,미니게임등 npc기능다루는 번호?

    [Header("퀘스트")]
    [SerializeField] GameObject[] quests;

    Quest currentQuest;     //현재 진행 해야하는 퀘스트
    bool questOn;   //퀘스트가 있음 on
    bool UIOn;

    Transform target;


    void Awake(){

    }
    void Start()
    {
        name_ui_position=transform.position;
        name_ui_position.y+=1.8f;
        //gameObject.transform.Find("NPC_Name").gameObject.transform.position=name_ui_position;
        //name_ui=gameObject.transform.Find("NPC_Name").gameObject.GetComponent<TextMesh>();
        //name_ui.text=npc_name;
        //name_ui.color=Color.black;
        Name3d.transform.position=name_ui_position;
        Name3d.text=npc_name;
        Name3d.color=Color.black;
        Name3d.characterSize=0.5f;
        //퀘스트 초기화
        if(quests.Length>0){
            currentQuest=quests[0].GetComponent<Quest>();
            questOn=true;
        }
        else questOn=false;
        UIOn=false;

        text_count=0;
        
    }


    // Update is called once per frame
    void Update()
    {
        if(NPCon&&!UIOn&&Input.GetButtonDown("Action")){
            //대화 시작기능만
            UI_NPCDialog.NPCChatEnter(NPCNum,this);
            UIOn=true;
            transform.LookAt(target);
            

            
            
        }

    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player") {
            NPCon=true;
            //Debug.Log("IN");
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Player"){ 
            NPCon=false;
            //UI_NPCDialog.NPCChatExit();
            //UIOff();
            //Debug.Log("OUT");
        }
    }

    void OnTriggerStay(Collider col){
        if(col.gameObject.tag=="Player"){
            target=col.transform;
        }
    }
    public void UIOff(){
        UIOn=false;
    }
    public Quest GetQuest(){
        if(questOn) return currentQuest;
        else return null;
    }
}
