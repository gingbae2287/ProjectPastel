using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MaterialSlot : MonoBehaviour,IDropHandler,IPointerEnterHandler,IPointerExitHandler {
    Item material;
    public Item Material{get{return material;}}
    Image MaterialImage;
    int itemCode;
    int colorCode;
    public int ItemCode{get{return itemCode;}}
    public int Colorcode{get{return colorCode;}}
    bool isEmpty;
    public bool IsEmpty{get{return isEmpty;}}
    DragItem dragItem;
    Color colorHide;
    Color colorShow;
    private void Awake() {
        dragItem=PlayerManager.Instance.inventory.dragItem;
        MaterialImage=GetComponent<Image>();
    }

    void Start(){
        Init();
        colorHide=new Color(1,1,1,0);
        colorShow=new Color(1,1,1,1);
        MaterialImage.color=colorHide;
    }

    public void SetMaterial(Item item){
        material=item;
        MaterialImage.sprite=item.ItemImage;
        itemCode=item.ItemCode;
        colorCode=item.ColorCode;
        MaterialImage.color=item.Color;
        isEmpty=false;
    }
    public void Init(){
        material=null;
        //MaterialImage.sprite=null;
        MaterialImage.color=colorHide;  //뒷 배경 이미지가 보이기 위해 투명하게만 해줌
        itemCode=0;
        isEmpty=true;
        colorCode=0;
    }

    

    ///드래그 앤 드롭
    public void OnDrop(PointerEventData data)
    {
        if(dragItem.IsDargging) 
        {
        //인벤창에서 아이템을 드래그해 놓았을 때
            /*if(isEmpty){
                
                    material=dragItem.Item;
                    MaterialImage.sprite=material.ItemImage;
                    isEmpty=false;
                    dragItem.DragOff();
            }*/

            if(!isEmpty){
                //인벤토리. 해당 아이템 획득
                //위의 과정 진행
                PlayerManager.Instance.inventory.AcquireItem(material);
            }
            //material=dragItem.Item;
            //MaterialImage.sprite=material.ItemImage;
           // isEmpty=false;
            //MaterialImage.color=colorShow;
            SetMaterial(dragItem.dragslot.item);
            PlayerManager.Instance.inventory.AcquireItem(material, -1);
            dragItem.DragOff();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isEmpty) return;
        PlayerManager.Instance.tooltip.gameObject.SetActive(true);
        Vector3 pos=transform.position;
        pos.x+=80;
        pos.y-=50;
        PlayerManager.Instance.tooltip.SetToolTip(material.ItemName,pos);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayerManager.Instance.tooltip.gameObject.SetActive(false);
    }
}