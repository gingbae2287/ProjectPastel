using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    //Animator UI_Animator;
    public string sceneName="SampleScene";

    void Awake(){
        //UI_Animator=GameObject.Find("UIAnimationImage").GetComponent<Animator>();

    }
    public void ClickStart(){
        gameObject.transform.parent.Find("UI_CreateCharacter").gameObject.SetActive(true);
        gameObject.SetActive(false);
        //SceneManager.LoadScene(sceneName);
    }
    public void ClickLoadGame(){
        gameObject.transform.parent.Find("UI_LoadGame").gameObject.SetActive(true);
        gameObject.SetActive(false);

    }

    public void ClickSetting(){

    }

    public void ClickExit(){
        gameObject.transform.parent.Find("UI_Confirm").gameObject.SetActive(true);
        //gameObject.SetActive(false);

    }
   
}
