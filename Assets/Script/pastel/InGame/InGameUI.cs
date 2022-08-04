using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    GameObject PauseMenu;
    GameObject ConfirmMsg;
    ///UI상태///
    bool PauseMenuOn;
    bool MapOn=false;
    bool InvenOn=false;
    bool RecipeOn=false;
    bool MailOn=false;
    bool QuestOn=false;
    bool MiniGameOn=false;
    bool ConfirmOn=false;

    private void Awake() {
        PauseMenu=gameObject.transform.Find("PauseMenu").gameObject;
        ConfirmMsg=gameObject.transform.Find("UI_Confirm").gameObject;
    }

    private void Update(){
        /*if(Input.GetButtonDown("PauseUI")){ //esc버튼
            if(ConfirmOn) UI_Confirm();
            else if(MapOn) UI_Map();
            else if(InvenOn) UI_Inven();
            else if (RecipeOn) UI_Recipe();
            else if (MailOn) UI_Mail();
            else if (QuestOn) UI_Quest();
            else if (QuestOn) UI_MiniGame();
            else PuaseUI();
        }
        if(Input.GetButtonDown("Map")){ //m버튼
            UI_Map();
        }
        if(Input.GetButtonDown("Inventory")){
            UI_Inven();
        }
        if(Input.GetButtonDown("Quest")){
            UI_Quest();
        }*/
    }
    public void PuaseUI(){
        if(!PauseMenuOn) {
            PauseMenu.SetActive(true);
            PauseMenuOn=true;
            //Time.timeScale=0;
        }
        else {
            PauseMenu.SetActive(false);
            PauseMenuOn=false;
            //Time.timeScale=1;
        }


    }
///******play screen menu button*****///
    /*
    public void Bt_Gathering(){
        UI_Recipe();
    }
    public void Bt_Crafting(){
        UI_Recipe();
        
    }
    public void Bt_Processing(){
        UI_Recipe();
        
    }
    public void Bt_Mail(){
        UI_Mail();
    }
    public void Bt_CharInfo(){
        
    }*/
   
//////----------------------------------////////////////
    
    public void UI_Recipe(){
        if(RecipeOn){ 
            gameObject.transform.Find("UI_Recipe").gameObject.SetActive(false);
            RecipeOn=false;
        }
        else {
            gameObject.transform.Find("UI_Recipe").gameObject.SetActive(true);
            RecipeOn=true;
        }
       
    }

    

    public void UI_MiniGame(){
        if(MiniGameOn){ 
            gameObject.transform.Find("UI_MiniGame").gameObject.SetActive(false);
            MiniGameOn=false;
        }
        else {
            gameObject.transform.Find("UI_MiniGame").gameObject.SetActive(true);
            MiniGameOn=true;
        }
    }
    /*
    public void UI_Map(){
        if(MapOn){
            gameObject.transform.Find("UI_Map").gameObject.SetActive(false);
            MapOn=false;

        } 
        else 
        {
            gameObject.transform.Find("UI_Map").gameObject.SetActive(true);
            
            MapOn=true;
        }
    }
 
    public void UI_Inven(){
        if(InvenOn){
            gameObject.transform.Find("UI_Inventory").gameObject.SetActive(false);
            InvenOn=false;

        } 
        else 
        {
            gameObject.transform.Find("UI_Inventory").gameObject.SetActive(true);
            
            InvenOn=true;
        }

    }
    public void UI_Mail(){
        if(MailOn){ 
            gameObject.transform.Find("UI_Mail").gameObject.SetActive(false);
            MailOn=false;
        }
        else {
            gameObject.transform.Find("UI_Mail").gameObject.SetActive(true);
            MailOn=true;
        }
       
    }
    public void UI_Quest(){
        if(QuestOn){ 
            gameObject.transform.Find("UI_Quest").gameObject.SetActive(false);
            QuestOn=false;
        }
        else {
            gameObject.transform.Find("UI_Quest").gameObject.SetActive(true);
            QuestOn=true;
        }
       
    }
    public void UI_Confirm(){
        if(ConfirmOn){ 
            gameObject.transform.Find("UI_Confirm").gameObject.SetActive(false);
            ConfirmOn=false;
        }
        else {
            gameObject.transform.Find("UI_Confirm").gameObject.SetActive(true);
            ConfirmOn=true;
        }

    }
    */


}