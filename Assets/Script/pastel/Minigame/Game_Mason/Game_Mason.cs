using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Mason : MonoBehaviour
{
    public CardGameManager cardGameManager;
    //public Transform _touchPoint;
    //public Transform _startPoint;

    bool isgaming;
    
    public void Bt_GameStart(){
        if(isgaming==true) return;
        isgaming=true;
        cardGameManager.GameStart();
    }
    public void Bt_GameStop(){
        if(isgaming==false) return;
        isgaming=false;
        cardGameManager.GameStop();

    }
    private void OnDisable() {
        Bt_GameStop();
        cardGameManager.Init();
    }
    private void OnEnable() {
        //cardGameManager.Init();  cardgamemanager오브젝트가 활성화 되기전에 실행
    }

}