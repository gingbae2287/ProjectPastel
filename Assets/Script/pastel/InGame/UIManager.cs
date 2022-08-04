using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//전체 UI관리 싱글톤 클래스
public class UIManager : MonoBehaviour {
    private static UIManager instance;
    public static UIManager Instance{
        get{
            if(instance==null) return null;
            
            return instance;
        }
    }
    public bool UIOn{get; private set;}     //켜진 ui있을경우
    public bool PauseOn{get; private set;}
    public bool canMove{get; private set;}  //특정 ui에서 플레이어 못움직임


    private GameObject currentUI;       //현재 켜진 ui

    [SerializeField] GameObject Map;
    [SerializeField] GameObject Mail;
    [SerializeField] GameObject Inven;
    [SerializeField] GameObject Quest;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject Confirm;
    [SerializeField] GameObject NPCDialog;
    [SerializeField] GameObject MiniGame;
    public bool miniGameOn{get; private set;}
    public bool npcDialogOn{get; private set;}

    private void Awake() {
        if(instance==null) 
        { 
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start() {
        UIOn=false;
        currentUI=null;
        canMove=true;
        PauseOn=false;
    }

    private void Update() {
        UIButton();
        ESCButton();
    }

    public void OpenUI(GameObject UI){
        //ui열면 이동제한이 있으므로 다른 ui열기도 불가능으로 설정
        //if(PauseOn) return;
        if(UIOn){

            if(currentUI==UI) {
                ColseUI();
                return;
            }
            //currentUI.SetActive(false);
        }
        else{
            currentUI=UI;
            currentUI.SetActive(true);
            UIOn=true;
            canMove=false;
        }

    }

    public void ColseUI(){
        if(!UIOn) return;
        UIOn=false;
        currentUI.SetActive(false);
        currentUI=null;
        canMove=true;
    }

    public void ESCButton(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(UIOn){
                if(currentUI==null) return;
                currentUI.SetActive(false);
                currentUI=null;
                UIOn=false;
                canMove=true;
            }
            else if(PauseOn){
                PauseOn=false;
                canMove=true;
                PauseMenu.SetActive(false);
            }
            else{
                //puase 메뉴
                PauseMenu.SetActive(true);
                canMove=false;
                PauseOn=true;
            }

        }
    }

    void UIButton(){
        if(PauseOn) return;     //단축키로 ui오픈은 pause메뉴 없을때만
        if(Input.GetButtonDown("Map")){ //m버튼
            
            UIMap();
        }
        if(Input.GetButtonDown("Inventory")){
            Debug.Log("인벤오픈");
            UIInven();
        }
        if(Input.GetButtonDown("Quest")){
            UIQuest();
        }
    }

    public void UIMap(){
        OpenUI(Map);
    }
    public void UIInven(){
        OpenUI(Inven);
    }
    public void UIQuest(){
        OpenUI(Quest);
    }
    public void UIMail(){
        OpenUI(Mail);
    }
    public void UIConfirm(){
        OpenUI(Confirm);
    }

    public void NpcDialogOn(){
        //OpenUI(NPCDialog);
        NPCDialog.SetActive(true);
        UIOn=true;
        canMove=false;
        npcDialogOn=true;
    }
    public void NpcDialogOff(){
        if(miniGameOn) return;
        NPCDialog.SetActive(false);
        UIOn=false;
        canMove=true;
        npcDialogOn=false;
    }

    public void MiniGameOn(){
        MiniGame.SetActive(true);
        UIOn=true;
        canMove=false;
        miniGameOn=true;
    }

    public void MiniGameOff(){
        MiniGame.SetActive(false);
        UIOn=false;
        //canMove=true;
        miniGameOn=false;

    }

    

}