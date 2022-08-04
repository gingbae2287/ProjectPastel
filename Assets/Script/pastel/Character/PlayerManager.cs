using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어와 관련된 스크립트 관리 매니저.
//싱글톤으로 구현

public class PlayerManager : MonoBehaviour {
    private static PlayerManager instance;
    //캐릭터 객체
    [SerializeField] char_dummy Character;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private GameObject QuickSlotPrefab;
    [SerializeField] public GameObject InvenSlotParent;
    [SerializeField] public GameObject QuickSlotParent;
    public Inventory inventory;
    public GameObject[] SlotObjs;
    public GameObject[] QuickSlotObjs;
    public int selectedSlot{get; private set;}
    public QuickSlot currentSlot;
    public TargetObj target;

    public int range{get; private set;}


    public UI_ToolTip tooltip;

    public bool CanMove{get; private set;}

    void Awake(){
        if(instance==null){
            instance=this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);


        //inventory=new Inventory();
        SlotObjs=new GameObject[inventory.InvenSize];
        for(int i=0;i<inventory.InvenSize;i++){
            GameObject tmpSlot=(GameObject)Instantiate(slotPrefab, new Vector2(0,0), Quaternion.identity);
            SlotObjs[i]=tmpSlot;
            inventory.slots[i]=SlotObjs[i].GetComponent<Slot>();
            tmpSlot.transform.SetParent(InvenSlotParent.transform);
            
        }
        QuickSlotObjs=new GameObject[8];
        for(int i=0;i<8;i++){
            GameObject tmpSlot=(GameObject)Instantiate(QuickSlotPrefab, new Vector2(0,0), Quaternion.identity);
            QuickSlotObjs[i]=tmpSlot;
            inventory.quickSlots[i]=QuickSlotObjs[i].GetComponent<QuickSlot>();
            QuickSlotObjs[i].transform.SetParent(QuickSlotParent.transform);

        }
        selectedSlot=0;
        range=2;
    }

    void Update(){
        if(!UIManager.Instance.canMove) return;
        if(Input.GetMouseButtonDown(0))
        {
            inventory.quickSlots[selectedSlot].Use1();
            Character.Action();
        }
        if(Input.GetMouseButtonDown(1))
        {
            inventory.quickSlots[selectedSlot].Use2();
        }
    }
    public static PlayerManager Instance
    {
        get
        {
            if (instance==null)
            {
                return null;
            }
            return instance;
        }
    }
    public void ChangeSlotParent(GameObject obj){
        for(int i=0;i<inventory.InvenSize;i++){
            SlotObjs[i].transform.SetParent(obj.transform);
        }
    }
    public void InitSlotParent(){
        for(int i=0;i<inventory.InvenSize;i++){
            SlotObjs[i].transform.SetParent(InvenSlotParent.transform);
        }
    }

    public void ChangeSlot(int num){
        inventory.quickSlots[selectedSlot].onHand=false;
        selectedSlot = num;
        inventory.quickSlots[selectedSlot].onHand=true;
        currentSlot=inventory.quickSlots[selectedSlot];
        /*if(!inventory.quickSlots[selectedSlot].isEmpty) {Character.OnHand(inventory.quickSlots[selectedSlot].item);
        Debug.Log("슬롯있음");
        }
        else Character.OnHand(null);*/
    }
    
}