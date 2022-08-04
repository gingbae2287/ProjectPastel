using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RewardItem{
    public Item item;
    public int amount;

}
[System.Serializable]
public class SelectDialog{
    [Header("대화 선택지")]
    public string dialog;
    [Header("선택시 이동할 대화 Index")]
    public int DialogIdx;
}
[System.Serializable]
public class Dialog{
    [HideInInspector]
    public string name="대사";
    [Header("대사입력")]
    public string[] dialog;
    [Header("선택대화창")]
    public SelectDialog[] selectDialogs;
    bool selectOn;

    int page=0;
    public int Page{get{return page;}set{value=page;}}

    //퀘스트 완료
    



    public void DialogReset(){
        page=0;
    }
}


public class Quest : MonoBehaviour
{
    [Header("퀘스트 대화")]
    public Dialog[] QuestDialog;   //퀘스트 선택시 이어지는 대화. 첫행: 0=기본 대화 , 1~n: 선택 대화창에따른 대화흐름
    int dialogNum;  //현재 대화중인 대화 번호

    [Header("보상")]
    //bool haveReward;    //보상 여부
    bool questComp;     //퀘스트 완료 여부
    public bool QuestComp{get{return questComp;}set{value=questComp;}}

    void Start(){
        dialogNum=0;
        questComp=false;
        //GameObject obj=Instantiate(DialogPrefab, Vector3.zero, Quaternion.identity);
    }
    public Dialog GetDialog(){
        return QuestDialog[dialogNum];
    }
    public void ChangeDialog(int Idx){
        dialogNum=QuestDialog[dialogNum].selectDialogs[Idx].DialogIdx;
        if(QuestDialog.Length<=dialogNum){
            dialogNum=0;
        }
    }
    

    public void Reward(){
        //보상
    }

}



