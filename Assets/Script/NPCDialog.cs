using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    private GameObject NPCDialogPanel;
    private Text NPCText;

    void Start()
    {
        NPCDialogPanel = GameObject.Find("NPCDialogPanel");
        NPCText = GameObject.Find("NPCText").GetComponent<Text>();
        NPCDialogPanel.SetActive(false);
    }

    public void NPCChatEnter(string text)
    {
        NPCText.text = text;
        NPCDialogPanel.SetActive(true);
    }

    public void NPCChatExit()
    {
        NPCText.text = "";
        NPCDialogPanel.SetActive(false);
    }    
}
