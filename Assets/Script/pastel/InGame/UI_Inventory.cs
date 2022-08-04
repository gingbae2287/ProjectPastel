using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    //public int Inven_Size=20;
    Inventory inventory;
    
    public bool inventoryActive;
    //[SerializeField] private GameObject Slot_Prefab;
    //GameObject[] SlotObjs;
    //[SerializeField] private GameObject go_InventoryBase;
    [SerializeField] private GameObject SlotsParent;
    [SerializeField] private GameObject RecipeInvenSlotParent;
    Slot[] quickSlotInven;

    void Awake(){
       inventory=PlayerManager.Instance.inventory;

    }
    

    void Start()
    {
        

    }

    void Update()
    {

    }

    public void OpenInven(){

    }
    void OnEnable(){
        PlayerManager.Instance.ChangeSlotParent(SlotsParent);
    }

    private void OnDisable() {
        PlayerManager.Instance.InitSlotParent();
    }

}
