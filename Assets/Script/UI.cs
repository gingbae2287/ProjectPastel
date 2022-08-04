using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    Text HPbar;

    void Awake(){
        HPbar=GetComponent<Text>();
    }
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        HPbar.text="HP:"+ human.HP.ToString();
    }
}
