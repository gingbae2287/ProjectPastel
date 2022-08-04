using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSlot : MonoBehaviour
{
    public Recipe recipe;
    public Image RecipeImage;
    private bool canMake=false;
    public GameObject UI_Recipe;
    
    void Start(){
        RecipeImage.sprite=recipe.recipeImage;
        //SetColor(0.3f);     //레시피 색깔 투명
    }
    private void Update() {
        if(canMake) SetColor(1f);   //만들수 있으면 레시피색깔 변경
        //Check_canMake();
    }

    private void SetColor(float _alpha)
    {
        Color color = RecipeImage.color;
        color.a = _alpha;
        RecipeImage.color = color;
    }
    private void Check_canMake(){
    
        canMake=true;
    }

    public void Click(){
        UI_Recipe.GetComponent<UI_Recipe>().ShowRecipe(recipe.recipeImage, recipe.ex);
    }
}