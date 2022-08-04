using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake(){
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //실행중 화면이 꺼지지않음

        Screen.SetResolution(1920, 1080, true);


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
