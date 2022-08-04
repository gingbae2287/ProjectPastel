using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlots : MonoBehaviour{

    //[SerializeField] Item[] Materials=new Item[6];
    [SerializeField] MaterialSlot[] Materials=new MaterialSlot[6];

    int start,finish,itemCount;
    int[] colorArray;
    int randomColor;

    void Start(){
       // Materials=new Item[6];
        //for(int i=0;i<)
        start=-1;
        finish=5;
        colorArray=new int[6];
        
        //CraftingData.Instance.Add(101, new int[] {1,1,1,0,1,1});      //침대 테스트
    }

    float GetCraftingCode(){
        colorArray=new int[] {0,0,0,0,0,0};
        itemCount=0;
        //각 아이템의 코드를 3자리 수로 만들어 합쳐 조합코드를 얻어냄
        //ToString을 쓰고있지만 아이템코드를 512까지있다고 정한다면 비트연산자로도 가능
        //조합 배치만 맞으면 같은 조합법이므로 시작지점과 끝지점을 찾아 코드 추출
        for(int i=0;i<6;i++){
            if(!Materials[i].IsEmpty) {
                start=i;
                break;
            }
        }
        if(start==-1) return 0;
        for(int i=5;i>=0;i--){
            if(!Materials[i].IsEmpty) {
                finish=i;
                break;
            }
        }
        string craftingCode="1";
        for(int i=start;i<=finish;i++){
            int code;
            if(Materials[i].IsEmpty) code=0;
            else {
                code=Materials[i].ItemCode;
                colorArray[itemCount]=Materials[i].Colorcode;
                itemCount++;
            }
            

            //기존 잘못된 코드 3->300 으로 바꿔버림
            /*else if(code>99 && code<999) craftingCode+=code.ToString();
            else if(code>9&&code<100) craftingCode+=(code*10).ToString();
            else if (code>0 && code<10) craftingCode+=(code*100).ToString();*/

            //수정코드 string.PadRight 를 써서 문자열 자릿수 채우기. 3->003으로 변경, 0생략 방지 맨앞자리 1
            craftingCode+=(code.ToString().PadRight(3, '0'));
        }
        return float.Parse(craftingCode);
    }

    //UI닫을시 올라간 아이템들 다 return
    public void ReturnItem(){
        for(int i=0;i<Materials.Length;i++){
            if(!Materials[i].IsEmpty){
                PlayerManager.Instance.inventory.AcquireItem(Materials[i].Material);
                Materials[i].Init();
            }
        }
    }
    void ClearSlots(){
        for(int i=0;i<Materials.Length;i++){
                Materials[i].Init();
        }
    }

    private void OnDisable() {
        //제작(미니게임) UI닫히면 해당 스크립트 할당된 오브젝트도 disable됨
        ReturnItem();
    }
    public void Bt_Crafting(){
        float code=GetCraftingCode();
        int resultItem=CraftingData.Instance.CheckList(code);
        Debug.Log("조합시도. 현재 조합 코드: "+code);
        if(resultItem==0) Debug.Log("조합실패. 조합법이 없음");
        else {
            //조합성공
            randomColor=colorArray[Random.Range(0,itemCount)];
            ClearSlots();
            //PlayerManager.Instance.inventory.AcquireItem(resultItem);
            CraftingData.Instance.GiveItem(resultItem,randomColor);
            Debug.Log("조합성공. 아이템코드: "+resultItem+" 색깔코드: "+randomColor);

        }

    }


}