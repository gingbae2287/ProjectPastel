using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "New Recipe/Recipe")]


public class Recipe : ScriptableObject
{
   // Dictionary<Item, int> needItem;
   public enum RecipeType  // 레시피 유형
    {
        Gathering,
        Crafting,
        Pricessing,
    }
    
    public string recipeName;
    public Sprite recipeImage;
    public RecipeType recipeType;

    [SerializeField] int[] materialCodes;
    [SerializeField] int resultCode;
    public GameObject recipePrefab;
    public Sprite ex;   //레시피 설명
    
    /*
    public Item[] needItem;
    public int[] needCount;
    */

}