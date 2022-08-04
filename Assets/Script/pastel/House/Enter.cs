using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    bool trrigerOn;
    public string sceneName="House";

    private void Update() {
        if(Input.GetButtonDown("Action")) EnterHouse();
    }

    void EnterHouse(){
        
        if(!trrigerOn) return;
        SceneManager.LoadScene(sceneName);

    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player")
        {
            trrigerOn=true;
            Debug.Log("집 입구");
        }

    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Player")
        {
            trrigerOn=false;
        }
    }
}