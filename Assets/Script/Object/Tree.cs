using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tree : MonoBehaviour
{
    [SerializeField] GameObject woodBlockPrefab;
    WoodBlock[] woodBlocks;
    int woodCount;
    bool isBroken;
    void Start(){
        
        Respawn();
    }

    void Respawn(){
        isBroken=false;
        woodCount=Random.Range(3,5);
        woodBlocks=new WoodBlock[woodCount];
        for(int i=0;i<woodCount;i++){
            Vector3 pos=transform.position+new Vector3(0,i*1+1,0);
            GameObject tmp=(GameObject)Instantiate(woodBlockPrefab, pos, Quaternion.identity);
            tmp.transform.SetParent(transform);
            woodBlocks[i]=tmp.GetComponent<WoodBlock>();
            woodBlocks[i].Init(this);
        }
    }

    public void Break(){
        if(isBroken) return;
        isBroken=true;
        for(int i=0;i<woodCount;i++){
            woodBlocks[i].Break();
        }
        
    }

}