using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_NPCDialog : MonoBehaviour
{
    public GameObject NPCDialogPanel;
    public Text NPCChat;
    string[] dialog;
    int chatIdx;
    [SerializeField] UI_MiniGame miniGameUI;
    [Header("대화선택지 오브젝트")]

    [SerializeField] GameObject DialogPrefab;   //대화 선택지 오브젝트 프리펩
    //프리펩으로 오브젝트 및 스크립트 배열 생성 (대화선택지 미리 생성후 필요시 활성화)
    [SerializeField] GameObject SelectList;     //대화 선택지 오브젝트 리스트를 묶어논 오브젝트
    GameObject[] selectDialogObj;
    SelectDialogObj[] selectDialogScript;
    //SelectDialog[] selectDialog;    //quest로부터 선택지 받아와 저장
    int NPCNum;
    NPC currentNPC;
    Quest currentQuest;
    bool UIOn;
    bool isQuest;   //인사대화 와 퀘스트 대화 구분
    int quitIdx;
    Button[] buttons;   //npc대화창의 모든 버튼들

    void Awake()
    {
        NPCNum=-1;
        //NPCDialogPanel = GameObject.Find("NPCDialogPanel");
        //NPCText = GameObject.Find("NPCText").GetComponent<Text>();
        
        buttons=GetComponentsInChildren<Button>();
        selectDialogObj=new GameObject[5];
        selectDialogScript=new SelectDialogObj[5];
        for(int i=0;i<5;i++){
            GameObject obj=Instantiate(DialogPrefab, Vector3.zero, Quaternion.identity);
            selectDialogObj[i]=obj;
            selectDialogScript[i]=selectDialogObj[i].GetComponent<SelectDialogObj>();
            selectDialogObj[i].transform.SetParent(SelectList.transform);
            selectDialogScript[i].Init(this);
            selectDialogObj[i].SetActive(false);
        }
        UIOn=false;
        isQuest=false;
        NPCDialogPanel.SetActive(false);    //항상 마지막에
    }

    void Update(){
        if(UIOn&&Input.GetButtonDown("Action")){
            Chat();
        }
    }

    public void NPCChatEnter(int npcNum, NPC npc)
    {
        NPCNum=npcNum;
        //for(int i=0;i<text.Length;i++)
        //NPCChat.text = text;
        currentNPC=npc;
        //NPCDialogPanel.SetActive(true);
        UIManager.Instance.NpcDialogOn();
        dialog=currentNPC.chat;
        chatIdx=0;
        Chat();
        UIOn=true;
    }

    public void Chat(){
        
        if(chatIdx<dialog.Length){
            NPCChat.text = dialog[chatIdx];
            chatIdx++;

        }
        else if(isQuest){
            //퀘스트 대화 중일경우 선택지 보여줌
            ShowSelectList();
        }
    }
    //대화 선택지 활성화
    void ShowSelectList(){
        int count=currentQuest.GetDialog().selectDialogs.Length;
        SelectDialog[] curSelect=currentQuest.GetDialog().selectDialogs;
        for(int i=0; i<count;i++){
            selectDialogObj[i].SetActive(true);
            selectDialogScript[i].SetDialog(i, curSelect[i].dialog);
        }
        selectDialogObj[count].SetActive(true);
        selectDialogScript[count].SetDialog(count, "대화 종료");
        quitIdx=count;
    }
    public void Select(int Idx){
        //선택지 선택하면 호출
        chatIdx=0;
        for(int i=0;i<selectDialogObj.Length;i++){
            selectDialogObj[i].SetActive(false);
            //Debug.Log(i+"번째 선택지 비활성화");

        }
        if(Idx==quitIdx){
            //대화종료
            NPCChatExit();
        }
        else{
            //대화 상황 변경 또는 퀘스트 보상 변경
            currentQuest.ChangeDialog(Idx);
            dialog=currentQuest.GetDialog().dialog;
            Chat();
        }
    }

    

    public void NPCChatExit()
    {
        if(UIManager.Instance.miniGameOn) return;
        NPCChat.text = "";
        if(UIOn){
            currentNPC.UIOff();
            UIOn=false;
        }
        isQuest=false;
        //NPCDialogPanel.SetActive(false);
        UIManager.Instance.NpcDialogOff();
    }
    public void Bt_Craft(){
        if(UIManager.Instance.miniGameOn) return;
        if(NPCNum==-1) return;
        miniGameUI.MiniGameOn(NPCNum);
    }
    public void Bt_Quest(){
        if(UIManager.Instance.miniGameOn) return;
        currentQuest=currentNPC.GetQuest();
        chatIdx=0;
        if(currentQuest==null) {  
            string[] tmp={"지금은 퀘스트가 없어"};
            dialog=tmp;
            Chat();
        }
        else{
            dialog=currentQuest.GetDialog().dialog;
            Chat();
            isQuest=true;

        }
    }

    
}