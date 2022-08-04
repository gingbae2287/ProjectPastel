using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
public class UI_QuickSlots : MonoBehaviour
{   
    GameObject[] slotObjs;

    [SerializeField] private GameObject Image_selectedSlot;
    //private int selectedSlot;

    void Awake(){
        //slotObjs=new GameObject[8];
        //quickSlots=PlayerManager.Instance.inventory.quickSlots;
    }
    void Start()
    {
        slotObjs=PlayerManager.Instance.QuickSlotObjs;
        ChangeSlot(0);
    }

    void Update()
    {
        TryInputNumber();
    }

    private void TryInputNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeSlot(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeSlot(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeSlot(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeSlot(4);
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            ChangeSlot(5);
        else if (Input.GetKeyDown(KeyCode.Alpha7))
            ChangeSlot(6);
        else if (Input.GetKeyDown(KeyCode.Alpha8))
            ChangeSlot(7);

            //Mouse Scroll

/*
        if(Input.GetAxis("Mouse ScrollWheel")<0){
            if(selectedSlot==0) selectedSlot=7;
            else selectedSlot--;
            ChangeSlot(selectedSlot);

        }
        else if(Input.GetAxis("Mouse ScrollWheel")>0){
            if(selectedSlot==7) selectedSlot=0;
            else selectedSlot++;
            ChangeSlot(selectedSlot);
        }
        */
    }
    

     private void ChangeSlot(int num)
    {
        PlayerManager.Instance.ChangeSlot(num);
        Image_selectedSlot.transform.position=slotObjs[num].transform.position;
        //Execute();
    }
}