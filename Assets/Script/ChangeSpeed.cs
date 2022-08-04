using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour{

    char_dummy char_script;

    void Start(){
        char_script=GameObject.Find("Character_dummy").GetComponent<char_dummy>();
    }
}