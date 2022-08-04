using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CraftingData{
    //db파일 저장, 불러오기 구현하기
    //임시로 싱글톤으로 데이터 구현

    Item[] items;
    //아이템 관련
    string itemPath="dummyItems";
    
    private static CraftingData instance;
    public static CraftingData Instance{
        get{
            if(instance==null) instance=new CraftingData();
            return instance;
        }
    }


    Dictionary<float, int> CraftList = new Dictionary<float, int>();
    
    CraftingData(){
        Add(5, new int[] {1,0,0,0,0,0});
        Add(101, new int[] {1,1,1,0,1,1});      //침대 테스트
        
        items=new Item[200];
        Item[] tmpitem=Resources.LoadAll<Item>(itemPath);
        for(int i=0;i<tmpitem.Length;i++){
            items[tmpitem[i].ItemCode]=tmpitem[i];
            //Debug.Log("아이템 불러오기. 코드: "+tmpitem[i].ItemCode+" 이름: "+tmpitem[i].ItemName);
        }
    }
        

    void AddCraft(float craftingCode, int itemCode){
        CraftList.Add(craftingCode, itemCode);
    }

    public int CheckList(float craftingCode){
        int itemCode;
        if(CraftList.ContainsKey(craftingCode)) {
            CraftList.TryGetValue(craftingCode, out itemCode);
        }
        else itemCode=0;

        return itemCode;
    }

    public void Add(int result, int[] craftArray){
        string craftingCode="1";
        int start=0;
        int end=craftArray.Length;
        for(int i=0;i<craftArray.Length;i++){
            if(craftArray[i]!=0)
            { 
                start=i; 
                break;
            }
        }
        for(int i=craftArray.Length-1;i>=0;i--){
            if(craftArray[i]!=0)
            { 
                end=i+1; 
                break;
            }
        }
        for(int i=start;i<end;i++){
            if(craftArray[i]==0) craftingCode+="000";
            else  craftingCode+=(craftArray[i].ToString().PadRight(3, '0'));
        }
        CraftList.Add(float.Parse(craftingCode), result);
        Debug.Log("조합법 추가: "+craftingCode);
    }

    public void GiveItem(int itemCode, int colorCode=0, int itemCount=1){
        Item newItem=new Item();
        newItem.Copy(items[itemCode]);
        newItem.SetItemColor(colorCode);
        //Debug.Log("아이템주기: "+newItem.ItemName);
        PlayerManager.Instance.inventory.AcquireItem(newItem, itemCount);
    }
}