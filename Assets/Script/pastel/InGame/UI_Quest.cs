using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Quest : MonoBehaviour
{
    public void Bt_IngQuest(){

    }
    public void Bt_CompQuest(){
        
    }
    public void Bt_GiveUp(){
        
    }
    public void Bt_Back(){
        //gameObject.transform.parent.GetComponent<InGameUI>().UI_Quest();
        UIManager.Instance.ColseUI();
    }
}