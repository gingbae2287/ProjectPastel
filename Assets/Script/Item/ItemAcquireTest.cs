using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAcquireTest : MonoBehaviour
{
    Item[] item;
    private bool isPlayerEnter=false;
    //[SerializeField] Inventory inventory_script;
    string itemPath="dummyItems";

    void Awake(){
        item=new Item[200];
        Item[] tmpitem=Resources.LoadAll<Item>(itemPath);
        for(int i=0;i<tmpitem.Length;i++){
            item[tmpitem[i].ItemCode]=tmpitem[i];
            //Debug.Log("아이템 불러오기. 코드: "+tmpitem[i].ItemCode+" 이름: "+tmpitem[i].ItemName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TryGiveItem();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag=="Player"){
            
            isPlayerEnter=true;
        }

    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Player"){
            isPlayerEnter=false;
            
        }

    }
    private void TryGiveItem(){
        /*if(isPlayerEnter&&Input.GetButtonDown("Test")){
            int i=Random.Range(0,item.Length);
            PlayerManager.Instance.inventory.AcquireItem(item[i],1);
        }*/
        //편의기능
        if(Input.GetButtonDown("Test")){
            int i=Random.Range(1,4);
            GiveItem(1, i, 4);
            Debug.Log("아이템주기");
        }

    }
    void GiveItem(int itemCode, int colorCode=0, int itemCount=1){
        Item newItem=new Item();
        newItem.Copy(item[itemCode]);
        newItem.SetItemColor(colorCode);
        //Debug.Log("아이템주기: "+newItem.ItemName);
        PlayerManager.Instance.inventory.AcquireItem(newItem, itemCount);
    }
}
