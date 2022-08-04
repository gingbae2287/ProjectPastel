using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_test : MonoBehaviour
{
    bool NPCon;
    private GameObject NPCEvent;
    // Start is called before the first frame update
    string[] text={"안녕.","이름이뭐니?","난 바나나맨이야"};
    string npc_name="Banana Man";
    Vector3 name_ui_position;
    TextMesh name_ui;
    int text_count;

    void Awake(){

    }
    void Start()
    {
        name_ui_position=transform.position;
        name_ui_position.y+=2.5f;
        gameObject.transform.Find("NPC_Name").gameObject.transform.position=name_ui_position;
        name_ui=gameObject.transform.Find("NPC_Name").gameObject.GetComponent<TextMesh>();
        name_ui.text=npc_name;
        name_ui.color=Color.black;


        NPCEvent = GameObject.Find("NPCEvent");
        text_count=0;
    }


    // Update is called once per frame
    void Update()
    {
        if(NPCon&&Input.GetButtonDown("Action")){
            if(text_count==text.Length) {
                text_count=0;
                NPCEvent.GetComponent<NPCDialog>().NPCChatExit();
            }
            else NPCEvent.GetComponent<NPCDialog>().NPCChatEnter(text[text_count++]);
            
            human.HP++;
        }
        /*if(DialogOn&&Input.GetButtonDown("Action")){
            NPCDialogPanel.GetComponent<NPCDialog>().NPCChatExit();
        }*/
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player") {
            NPCon=true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Player"){ 
            
            NPCon=false;
            text_count=0;
            NPCEvent.GetComponent<NPCDialog>().NPCChatExit();
        }
    }
}
