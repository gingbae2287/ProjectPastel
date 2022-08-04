using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour{

    /* 청크 사이즈 계산
    343/16=21.4 =>x로 22개
    z로 17개
    */


    
    public static int chunk_size=16;
    public static int chunk_count_x=MapData.map_size_x/16;
    public static int chunk_count_z=MapData.map_size_z/16;

    GameObject[,] chunk;
    bool[,] isChunkLoad;

    void Awake(){
        chunk=new GameObject[chunk_count_x,chunk_count_z];
        isChunkLoad=new bool[chunk_count_x,chunk_count_z];
        //Instantiate(chunk)
        int k=0;
        for(int i=0;i<chunk_count_x;i++){
            for(int j=0;j<chunk_count_z;j++){
                chunk[i,j]=new GameObject("chunk"+k.ToString());
                k++;
                //chunk[i,j].transform.position=new Vector3(i*chunk_size,0,j*chunk_size);
                //Instantiate(chunk[i,j], new Vector3(0,0,0), Quaternion.identity);
                chunk[i,j].transform.SetParent(gameObject.transform);
            }
        }
        
    }
    public void SetBlockChunk(GameObject obj,int x, int z){  //블럭 좌표 받아와서 각 청크 자식으로 넣음

        obj.transform.SetParent(chunk[(int)(x/16),(int)(z/16)].transform);

    }

    public void SetChunk(GameObject obj,float x, float z){  // 오브젝트들의 좌표를 받아와서 해당 청크 자식으로 넣음
        obj.transform.SetParent(chunk[(int)(x/MapData.block_size.x/16),(int)(z/MapData.block_size.x/16)].transform);
    }

    public void ChunkUpdate(int x, int z){
        for(int i=0;i<chunk_count_x;i++){
            for(int j=0;j<chunk_count_z;j++){
                if(x-2<=i & i<=x+2 & z-2<=j & j<=z+2){
                    isChunkLoad[i,j]=true;
                    chunk[i,j].SetActive(true);
                }
                else {
                    isChunkLoad[i,j]=false;
                    chunk[i,j].SetActive(false);
                }
            }
        }
    }

}