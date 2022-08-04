using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public void Button_back_Title(){
        gameObject.transform.parent.Find("UI_Title").gameObject.SetActive(true);
        gameObject.SetActive(false);

    }


}