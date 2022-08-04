using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block{
    public int type;
    public bool visible;
    public GameObject obj;
    public Block(int type, bool visible, GameObject blockobj){
        this.type=type;
        this.visible=visible;
        this.obj=blockobj;

    }
}

public class block_dummy : MonoBehaviour
{
   /* public static int map_size_x=30;    //타일 개수
    public static int map_size_z=30;    //타일 개수/
    */
    public static int height=10;
    //Vector3 block_size=new Vector3(1.5f,1.5f,1.5f);     //타일 하나 크기 1.5m
    //public Block[,,] worldBlock=new Block[MapData.map_size_x,height,MapData.map_size_z];
    //public bool[,,] MapInfo=new bool[MapData.map_size_x,height,MapData.map_size_z];
    public GameObject[] block;

    ////청크 스크립트 불러오기///
    Chunk Chunk;

    void Start(){
        Chunk=GameObject.Find("Chunk").GetComponent<Chunk>();

        //block_size=block.transform.localScale;
        int[,,] mapPoint=MapData.MapPoint;

        for(int i=0;i<mapPoint.GetLength(0);i++){
            int[,] tmp={{mapPoint[i,0,0],mapPoint[i,0,1]},{mapPoint[i,1,0],mapPoint[i,1,1]}};
            CreateRegion(tmp);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     IEnumerator InitGame()
    {
        //맵

        
        yield return StartCoroutine(MapInit());
        //구름

        //동굴
    }

    IEnumerator MapInit(){

        yield return null;
    }

    /*IEnumerator CreateBlock(int y, Vector3 blockpos, bool visual){
        if(visual){
            GameObject BlockObj=(GameObject)Instantiate(block[0], blockpos, Quaternion.identity);
            BlockObj.transform.SetParent(GameObject.FindGameObjectWithTag("Environment").transform);
            worldBlock[(int)blockpos.x, (int)blockpos.y, (int)blockpos.z]=new Block(1,visual, BlockObj);

        }
        else{
            worldBlock[(int)blockpos.x, (int)blockpos.y, (int)blockpos.z]=new Block(1,visual,null);
        }
        yield return null;
    }*/

    //사각형으로나눠진 구역 생성
    void CreateRegion(int[,] rect){
        int x1=rect[0,0];
        int x2=rect[1,0];
        int z1=rect[0,1];
        int z2=rect[1,1];
        for(int x=x1;x<=x2;x++){
            for(int z=z1;z<=z2;z++){
                Vector3 pos=new Vector3(MapData.block_size.x*x,0,MapData.block_size.z*z);
                GameObject Block=(GameObject)Instantiate(block[0], pos, Quaternion.identity);
                Chunk.SetBlockChunk(Block,x,z);
                //Block.transform.SetParent(GameObject.FindGameObjectWithTag("DummyBlock").transform);
            }
        }
    }
}
