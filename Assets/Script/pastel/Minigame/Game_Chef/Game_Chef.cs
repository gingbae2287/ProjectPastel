using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Chef : MonoBehaviour
{
    [SerializeField] CookingObj cookObj;
    [SerializeField] CraftingObj craftObj;

    bool isgaming;
    
    public void Bt_GameStart(){
        if(isgaming==true) return;
        isgaming=true;
        cookObj.GameStart();
        craftObj.GameStart();

       
    }
    public void Bt_GameStop(){
        if(isgaming==false) return;
        isgaming=false;
        cookObj.GameStop();
        craftObj.GameStop();

    }
    private void OnDisable() {
        Bt_GameStop();
        cookObj.Init();
        craftObj.Init();
    }

}