using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mail : MonoBehaviour
{
    public Image[] Icon_Mail= new Image[2]; //0: 안읽음 1: 읽음
    public Image CheckRead;
    public Text Title_Mail; 
    public string title;
    public string text;
    bool isRead=false;

    void Start(){
        Title_Mail.text=title;
        CheckRead.sprite=Icon_Mail[0].sprite;
    }
    /*
    void Update(){
        if(isRead) CheckRead.sprite=Icon_Mail[1].sprite;
    }
    */

    public void Click(){
        if(!isRead) {
            CheckRead.sprite=Icon_Mail[1].sprite;
            isRead=true;
        }
        // 내용 보여주기

    }
}
