using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class speedTest : MonoBehaviour
{
    InputField speedValue;
    [SerializeField]char_dummy char_script;

    void Start(){
        speedValue=gameObject.GetComponent<InputField>();
        //char_script=GameObject.Find("Character_dummy").GetComponent<char_dummy>();
    }

    public void ChangeSpeed(){
        float speed=0;
        if(float.TryParse(speedValue.text, out speed)) char_script.SpeedChange(speed);
        else speedValue.text="";

        /*try{
            int speed=int.Parse(speedValue.text);
            char_script.SpeedChange((float)speed);
        }
        catch (FormatException)
        {
           speedValue.text="";
        }*/
        
    }
}