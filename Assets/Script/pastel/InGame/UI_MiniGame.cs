using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MiniGame : MonoBehaviour
{
    public GameObject minigameScreen;
    public GameObject _resultScreen;
    [SerializeField] GameObject[] miniGameList;
    [SerializeField] GameObject invenSlotParent;

    //[SerializeField] UI_CraftingGauge craftingGauge;
    int NPCNum;
    
    void Start(){
        NPCNum=-1;
    }
    public void Bt_Back(){
        //gameObject.transform.parent.GetComponent<InGameUI>().UI_MiniGame();
        PlayerManager.Instance.InitSlotParent();
        UIManager.Instance.MiniGameOff();

        //minigameScreen.SetActive(false);
    }


    public void Bt_ConfirmResult(){
        _resultScreen.SetActive(false);
    }
    public void MiniGameOn(int npcNum){
        
        //minigameScreen.SetActive(true);
        UIManager.Instance.MiniGameOn();
        if(NPCNum!=-1){
            miniGameList[NPCNum].SetActive(false);
        }
        NPCNum=npcNum;
        miniGameList[NPCNum].SetActive(true);

        PlayerManager.Instance.ChangeSlotParent(invenSlotParent);

        //craftingGauge.TextDisable();
    }
}