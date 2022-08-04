using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customizing : MonoBehaviour
{

    public void Button_back_CreateCharacter()
    {
        gameObject.transform.parent.Find("UI_CreateCharacter").gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

}