using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName="GamePlay";
    public void SelectMale(){

    }

    public void SelectFemale(){
        
    }

    public void Button_GoTitle(){
        gameObject.transform.parent.Find("UI_Title").gameObject.SetActive(true);
        gameObject.SetActive(false);

    }
    public void Button_Go_Customizing(){
        gameObject.transform.parent.Find("UI_Customizing").gameObject.SetActive(true);
        gameObject.SetActive(false);

    }
    public void Button_Start(){
        SceneManager.LoadScene(sceneName);
    }

}
