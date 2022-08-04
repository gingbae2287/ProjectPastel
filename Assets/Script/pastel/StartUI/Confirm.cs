using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confirm : MonoBehaviour
{
    public string confirmMessage;
    public Text text;
    void Awake(){
        text=GameObject.Find("ConfirmMessage").GetComponent<Text>();
        text.text="정말로 종료하시겠습니까?";
    }
    public void Button_YES(){
#if UNITY_EDITOR
UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
        //gameObject.SetActive(false);
        //return true;

    }
    public void Button_NO(){
        gameObject.SetActive(false);
        //return false;
        
    }
}