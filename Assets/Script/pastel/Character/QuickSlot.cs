using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuickSlot : Slot
{
    public bool onHand{get; set;}    //퀵슬롯 선택시 true
    protected override void Awake(){
        onHand=false;
        dragItem=PlayerManager.Instance.inventory.dragItem;
    }
        

    public void Use1(){
        //마우스 왼클릭시
        if(!onHand) return;
        if(isEmpty) return;
        Debug.Log("왼쪽버튼 사용");
    }

    public void Use2(){
        //마우스 오른클릭시
        if(!onHand) return;
        if(isEmpty) return;
        Debug.Log("오른쪽버튼 사용");
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        return;
    }

    





}