using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WoodBlock : MonoBehaviour
{
    Tree ParentTree;
    IEnumerator corou;
    bool isBroken;

    public void Init(Tree tree){
        ParentTree=tree;
        isBroken=false;
    }
    public void Break(){
        if(isBroken) return;
        Debug.Log("나무 부서짐");
        isBroken=true;
        ParentTree.Break();
        corou=DestroyObj();
        StartCoroutine(corou);
    }

    IEnumerator DestroyObj(){
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag=="Target"){
            if(PlayerManager.Instance.target.action){
                if(PlayerManager.Instance.currentSlot.item.property.treecut){
                    Break();
                }
            }
        }
    }
}