using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]

[System.Serializable]
public class ItemProperty{
    public bool treecut; 
}
public class Item : ScriptableObject
{
    // Start is called before the first frame update
    public enum ItemType  // 아이템 유형
    {
        Equipment,
        Used,
        ETC,
    }
    public ItemType itemType;
    public enum ItemColor{
        None,   //0
        Brown,  //1
        DrakBrown,  //2
        LightBrown,  //3
        Gray,  //4
        Green,  //5
        DarkGreen,  //6
        Blue,  //7
        Pink,  //8
        Purple,  //9
        Red,  //10
        Orange,  //11
        Yellow,  //12

    }
    [SerializeField] ItemColor itemColor;
    private string colorName;
    [SerializeField] string itemName;
    public string ItemName{
        get{
            if(itemColor==ItemColor.None) return itemName;
            else return colorName+itemName;
        }
    }
    
    [SerializeField] Sprite itemImage;
    public Sprite ItemImage{get{return itemImage;}}
    //public string itemColor;
    //[SerializeField] private GameObject itemPrefab;
    [SerializeField] private int itemCode;
    public int ItemCode{get{return itemCode;}}
    [Multiline(3)]
    public string ex;   //아이템 설명
    Color color;
    public Color Color{get{return color;}}
    public int ColorCode{get{return (int)itemColor;}}
    public ItemProperty property;



    void Awake() {
        GetItemColor();
        /*if(itemColor!=ItemColor.None){
            itemName=colorName+itemName;
        }*/
    }

    Color GetItemColor(){
        
        switch(itemColor){
            case ItemColor.None:
            color=new Color(1,1,1,1);
            break;

            case ItemColor.Brown:
            color=new Color(0.5f,0.5f,0.5f,1);
            colorName="갈색 ";
            break;

            case ItemColor.DrakBrown:
            color=new Color(0.3f,0.3f,0.3f,1);
            colorName="짙은 갈색 ";
            break;

            case ItemColor.LightBrown:
            color=new Color(0.7f,0.7f,0.7f,1);
            colorName="옅은 갈색 ";
            break;

            case ItemColor.Gray:
            color=Color.gray;
            colorName="잿빛 ";
            break;

            case ItemColor.Green:
            color=Color.green;
            colorName="녹색빛 ";
            break;

            case ItemColor.DarkGreen:
            color=new Color(0.7f,0.7f,0.7f,1);
            colorName="진한 녹색 ";
            break;

            case ItemColor.Blue:
            color=Color.blue;
            colorName="파란 ";
            break;

            case ItemColor.Pink:
            color=new Color(0.7f,0.7f,0.7f,1);
            colorName="분홍 ";
            break;

            case ItemColor.Purple:
            color=new Color(0.7f,0.7f,0.7f,1);
            colorName="보라 ";
            break;

            case ItemColor.Red:
            color=Color.red;
            colorName="붉은 ";
            break;

            case ItemColor.Orange:
            color=new Color(0.7f,0.7f,0.7f,1);
            colorName="주황 ";
            break;

            case ItemColor.Yellow:
            color=Color.yellow;
            colorName="노란 ";
            break;



        }
        return color;
    }

    public void SetItemColor(int colorCode){
        itemColor=(ItemColor)colorCode;
        GetItemColor();
    }

    //아이템 주기 명령어에서 아이템 객체가 새로 생성되지 않고 포인터로 중복된 것을 가리켜 색이 다른게 들어와도 같은 아이템으로 인식해 버렸다. 그래서 copy로 item데이터 복사.
    public void Copy(Item item){
        itemColor=item.itemColor;
        itemCode=item.itemCode;
        itemName=item.itemName;
        itemType=item.itemType;
        itemImage=item.itemImage;
        item.SetItemColor((int)itemColor);
        property=item.property;

    }
}
