using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Woodworking : MonoBehaviour
{
    public NoteManager noteManager;
    //public Transform touchPoint;
    //public Transform startPoint;

    bool isgaming;
    
    public void Bt_GameStart(){
        if(isgaming==true) return;
        isgaming=true;
        noteManager.GameStart();
    }
    public void Bt_GameStop(){
        if(isgaming==false) return;
        isgaming=false;
        noteManager.GameStop();

    }
    private void OnDisable() {
        Bt_GameStop();
        noteManager.Init();
    }
}