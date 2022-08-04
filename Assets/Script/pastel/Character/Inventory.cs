using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Inventory
{
    int invenSize=30;
    public int InvenSize{get{return invenSize;}}
    
    
    public Slot[] slots;
    public QuickSlot[] quickSlots;
    public DragItem dragItem;

    /*void Awake(){
        slots=new Slot[invenSize];
        invenParent=PlayerManager.Instance.InvenSlotParent;
        for(int i=0;i<invenSize;i++){
            GameObject tmpSlot=(GameObject)Instantiate(slotPrefab, new Vector2(0,0), Quaternion.identity);
            SlotObjs[i]=tmpSlot;
            slots[i]=SlotObjs[i].GetComponent<Slot>();
            tmpSlot.transform.SetParent(invenParent.transform);
            
        }

    }*/
    public Inventory(){
        slots=new Slot[invenSize];
        quickSlots= new QuickSlot[8];

    }
    public void DragItemOff(){
        dragItem.gameObject.SetActive(false);
    }
    public void DragItemOn(){
        dragItem.gameObject.SetActive(true);
    }
    public void AcquireItem(Item item, int count=1){
        //아이템 있는지 먼저 체크
        if(Item.ItemType.Equipment != item.itemType){
            //
        }
        for(int i=0;i<slots.Length;i++){
                if(slots[i].item!=null){
                    if(slots[i].item.ItemCode==item.ItemCode && slots[i].item.ColorCode==item.ColorCode){
                        slots[i].SetSlotCount(count);
                        return;
                    }
                }
        }
        //없으면 새로 등록
        for(int i=0;i<slots.Length;i++){
            if(slots[i].item==null){
                slots[i].AddItem(item,count);
                return;
            }
        }
    }

    
}