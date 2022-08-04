using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_ToolTip: MonoBehaviour{
    [SerializeField]Text itemName;
    bool tooptipOn;
    public bool TooltipOn{get{return tooptipOn;}}
    
    private void Awake() {
        tooptipOn=false;
        gameObject.SetActive(false);
    }

    public void SetToolTip(string name,Vector3 pos){
        itemName.text=name;
        transform.position=pos;

    }
}