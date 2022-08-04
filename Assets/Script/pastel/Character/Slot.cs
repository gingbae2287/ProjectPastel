//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerEnterHandler,IPointerExitHandler,IDropHandler
{
    public Item item;
    public int itemCount{get; private set;}
    string itemName;
    public string ItemName{get{return itemName;}}
    
    int itemCode;
    public int ItemCode{get{return itemCode;}}

    public bool isEmpty{get; private set;}
    bool isDragging;

    [Header("오브젝트 위치 할당")]
    [SerializeField] public Text text_Count;
    [SerializeField] public GameObject go_CountImage;
    [SerializeField] public Image itemImage;
    //public Image ItemImage{get{return itemImage;}}
    protected DragItem dragItem;
    protected virtual void Awake() {
        dragItem=PlayerManager.Instance.inventory.dragItem;
    }

    protected virtual void Start() {
        ClearSlot();
        isDragging=false;
    }

    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    
    public void AddItem(Item _item, int _count=1){
        item=_item;
        isEmpty=false;
        itemCount=_count;
        itemImage.sprite=item.ItemImage;
        itemCode=item.ItemCode;
        itemImage.color=item.Color;
        itemName=item.ItemName;
        if(item.itemType!=Item.ItemType.Equipment){
            go_CountImage.SetActive(true);
            
            text_Count.text=itemCount.ToString();
        }
        else{
            text_Count.text="0";
            go_CountImage.SetActive(false);
        }
        //아이템 이미지 활성화

        SetColor(1);
    }

    public void SetSlotCount(int count){
        if(itemCount+count<0) {
            Debug.Log("아이템 개수모자람.");
            return;
        }
        itemCount+=count;
        text_Count.text=itemCount.ToString();

        if(itemCount<=0) ClearSlot();
    }

    public void ClearSlot(){
        item=null;
        isEmpty=true;
        itemCount=0;
        itemImage.sprite=null;
        itemImage.color=new Color(1,1,1,0);
        itemCode=0;
        //아이템 이미지 비활성화
        SetColor(0);
        text_Count.text="0";
        go_CountImage.SetActive(false);
    }


    ///드래그앤드롭///


    

    public void OnBeginDrag(PointerEventData data){
        //드래그 클릭 시작
        
        if(isEmpty) return; //비었으면 아무작용 X       => 여기서 return을 해도 마우스를 움직이고 놓으면 ondrag, onenddrag가 모두 실행
        dragItem.gameObject.SetActive(true);
        //dragItem.DragOn(item);
        dragItem.DragOn(this);
        isDragging=true;
     
        
    }
    public void OnDrag(PointerEventData data){
        //드래그 중
        if(isDragging){
            dragItem.transform.position=data.position;
            
        }
    }
    public void OnEndDrag(PointerEventData data){
        //드래그 클릭 놓았을 때
        if(!isDragging) return;
        isDragging=false;
        itemImage.raycastTarget=true;
        //MaterialSlot에 아이템 성공적으로 올리면 dragItem.IsDragging=false
        if(!dragItem.IsDargging){
        }
        dragItem.DragOff();
        dragItem.gameObject.SetActive(false);
        

        

        //다른 인벤토리 창으로 옯기면 해당 인벤토리 창과 정보 교환
    }

    //마우스커서가 오브젝트 위에 올라갔을때
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if(isEmpty) return;
        PlayerManager.Instance.tooltip.gameObject.SetActive(true);
        Vector3 pos=transform.position;
        pos.x+=80;
        pos.y-=50;
        PlayerManager.Instance.tooltip.SetToolTip(itemName,pos);
    }
    //커서 떨어졌을때
    public void OnPointerExit(PointerEventData eventData)
    {
        PlayerManager.Instance.tooltip.gameObject.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(dragItem.IsDargging) 
        {
            dragItem.ItemSwap(this);
            dragItem.DragOff();
        }
        
    }
}
