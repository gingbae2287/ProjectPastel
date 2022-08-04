using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GetQuest : MonoBehaviour
{

    public void Bt_Back(){
        //gameObject.transform.parent.GetComponent<InGameUI>().UI_GetQuest();
        gameObject.SetActive(false);
    }
}