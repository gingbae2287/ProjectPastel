using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragItem : MonoBehaviour {
    /*Item item;
    public Item Item{get{return item;}}
    */
    Image itemImage;
    public Slot dragslot{get; private set;}
    bool isDargging;
    bool dragComp;  //드래그드랍 성공여부
    Color itemColor;
    
    public bool IsDargging{get{return isDargging;}}

    private void Awake() {
        itemImage=GetComponent<Image>();
        isDargging=false;
        gameObject.SetActive(false);
        dragComp=false;
    }

    void Start(){
    }
    /*
    public void DragOn(Item Item){
        item=Item;
        itemImage.sprite=item.ItemImage;
        itemColor=item.Color;
        itemImage.color=itemColor;
        isDargging=true;
    }
    */

    public void DragOn(Slot slot){
        dragslot=slot;
        itemImage.sprite=slot.item.ItemImage;
        itemColor=slot.item.Color;
        itemImage.color=itemColor;
        isDargging=true;
    }
    public void DragOff(){
        //MaterialSlot에 아이템이 올라갔다면.
        isDargging=false;
        //itemImage.sprite=null;
        //gameObject.SetActive(false);  제일 마지막인 OnEndDrag에서 비활성화
    }

    public void DragComp(){
        isDargging=false;
        dragComp=true;
    }

    public void ItemSwap(Slot slot){
        if(!isDargging) return;
        if(slot==dragslot) return;


        if(slot.isEmpty){
            slot.AddItem(dragslot.item, dragslot.itemCount);
            dragslot.ClearSlot();
        }
        else{
            Item tmpItem=new Item();
            int tmpCount;
            tmpItem=dragslot.item;
            tmpCount=dragslot.itemCount;
            dragslot.ClearSlot();
            dragslot.AddItem(slot.item, slot.itemCount);
            slot.ClearSlot();
            slot.AddItem(tmpItem, tmpCount);
        }
    }

}