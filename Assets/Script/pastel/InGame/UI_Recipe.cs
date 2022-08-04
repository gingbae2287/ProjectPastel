using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Recipe : MonoBehaviour
{
    public Image BigImage;
    public Image Ex;



    void Start(){
        
    }
    public void UI_Bt_Gathering(){

    }
    public void UI_Bt_Crafting(){
        
    }
    public void UI_Bt_Processing(){
        
    }
    public void ShowRecipe(Sprite BigImage, Sprite ex){
        this.BigImage.sprite=BigImage;
        this.Ex.sprite=ex;

    }
    
    public void Bt_Back(){
        gameObject.transform.parent.GetComponent<InGameUI>().UI_Recipe();
        //gameObject.SetActive(false);
    }
}