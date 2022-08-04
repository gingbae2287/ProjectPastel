using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    private InGameUI UIScript;

    void Start(){
        UIScript=gameObject.transform.parent.gameObject.GetComponent<InGameUI>();
    }


///******pause menu button*****///
    public void Bt_UI_Map(){
        UIManager.Instance.UIMap();

    }
    public void Bt_UI_Inven(){
         UIManager.Instance.UIInven();
    }

    public void Bt_UI_Recipe(){
        UIScript.UI_Recipe();
    }
    public void Bt_UI_Mail(){
         UIManager.Instance.UIMail();
    }
     public void Bt_UI_Quest(){
         UIManager.Instance.UIQuest();
    }
    public void GameEnd(){
        UIManager.Instance.UIConfirm();

    }

}