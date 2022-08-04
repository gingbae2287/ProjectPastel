using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class SelectDialogObj : MonoBehaviour
{
    [Header("대화 내용")]
    [SerializeField] GameObject textObj;
    Text text;
    UI_NPCDialog NPCUI;

    int dialogNum; //대화 선택지 번호. 버튼 클릭시 이 번호를 quest로 보내 어떤 선택지가 눌렸는지 판별
    void Awake(){
        text=textObj.GetComponent<Text>();

    }
    public void Init(UI_NPCDialog uinpc){
        NPCUI=uinpc;
    }

    public void Bt_Click(){
        Debug.Log(dialogNum+"선택지클릭");
        NPCUI.Select(dialogNum);
    }
    public void SetDialog(int num, string dialog){
        dialogNum=num;
        text.text=dialog;
    }
}