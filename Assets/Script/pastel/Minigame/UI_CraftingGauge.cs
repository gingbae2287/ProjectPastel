using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CraftingGauge : MonoBehaviour
{   //제작게이지 UI
    [SerializeField] Image _fillBar;
    [SerializeField] Text text;
    int _gaugeCount;
    int _maxGauge=40;

    public int MaxGauge{get{return _maxGauge;} set{_maxGauge=value;}}

    void Update(){

    }

    public void GaugeUpdate(int count){
        _gaugeCount=count;
        _fillBar.fillAmount=(float)_gaugeCount/(float)_maxGauge;
        text.text=string.Format("{0}\n/\n{1} 제작 게이지",_gaugeCount,_maxGauge);
    }
    public void TextDisable(){
         text.text="";
    }
}