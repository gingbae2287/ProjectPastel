using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour

{   
    static int noteCount=10;       //노트개수
    [Header("음악 관련")]
    AudioSource music;
    public int bpm=60;
    public float noteSpeed=3;
    public int succeessRange=10;
    double currentTime=0;
    bool musicStart;   //음악시작했는지
    [Header("게임 오브젝트")]

    [SerializeField] GameObject note;
    GameObject[] notes=new GameObject[noteCount];
    
    
    int noteIdx=0;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform touchPoint;
    [SerializeField] Text succeessText;
    [SerializeField] UI_CraftingGauge craftingGauge;
    
    GameObject checkNote;
    
    int craftingCount; //제작 게이지. 얼마나 성공했나.
    bool gaming;


    void Start(){
        music=GetComponent<AudioSource>();
        for(int i=0;i<noteCount;i++){
            notes[i]=Instantiate(note, startPoint.position,Quaternion.identity);
            notes[i].transform.SetParent(transform);
            notes[i].GetComponent<Note>().NoteSpeed=noteSpeed;
            notes[i].SetActive(false);
        }
        gaming=false;
        musicStart=false;
        craftingCount=0;
        craftingGauge.GaugeUpdate(craftingCount);
        currentTime=0;
    }

    void Update(){
        if(gaming){    //게임시작하면
            currentTime+=Time.deltaTime;   //음악 시작시 시간흐름
            if(currentTime>=60d/bpm){  //비트에 맞춰 노트 생성
                notes[noteIdx++].SetActive(true);
                currentTime-=60d/bpm;
                if(noteIdx>=noteCount) noteIdx=0;
            }
            /*if(Input.GetKeyDown(KeyCode.Space)){
                CheckSuccess();
            }*/  //마우스 클릭임 

            //음악시작하기
            if(!musicStart)    StartMusic();
        }
    }
    public void Init(){
        gaming=false;
        musicStart=false;
        checkNote=null;
        craftingCount=0;
        craftingGauge.GaugeUpdate(craftingCount);
        currentTime=0;
        succeessText.text="";
        noteIdx=0;
        music.Stop();
        for(int i=0;i<noteCount;i++){
            ResetNote(notes[i]);
        }

        
    }
    void StartMusic(){
        if(Mathf.Abs(notes[0].transform.position.x-touchPoint.position.x)<90){
            musicStart=true;
            music.Play();
        }
    }
    public void Bt_TouchPoint(){
        if(gaming){
            CheckSuccess();
        }

    }

    public void GameStart(){
        //StartCoroutine("GameGo");
        //music.Play();    //첫 노트가 터치포인트에 오면 음악시작으로 바꿈
        musicStart=false;
        checkNote=null;
        craftingCount=0;
        craftingGauge.GaugeUpdate(craftingCount);
        gaming=true;
        succeessText.text="";
        noteIdx=0; //음악 시작을 위해 노드 idx초기화
    }

    public void GameStop(){
        //게임종료
        /*succeessText.text="";
        
        craftingCount=0;
        craftingGauge.GaugeUpdate(craftingCount);
        currentTime=0;
        gaming=false;
        musicStart=false;
        music.Stop();*/
        Init();
        for(int i=0;i<noteCount;i++){
            ResetNote(notes[i]);
        }
    }

    void CheckSuccess(){
       //Debug.Log(checkNote.transform.position.x+" " +touchPoint.position.x);
        if(checkNote==null){
            //터치포인트에 노트가 없을 때
            
            
        }
        else if(Mathf.Abs(checkNote.transform.position.x-touchPoint.position.x)<succeessRange){
            //성공 Good
            craftingCount+=1;
            succeessText.text="Good";
            succeessText.color=Color.blue;
            craftingGauge.GaugeUpdate(craftingCount);
            ResetNote(checkNote);
        }
        
        else{
            //노트 들어왔지만 범위 밖일때 Bad
            succeessText.text="Bad";
            succeessText.color=Color.red;
            ResetNote(checkNote);
        }
    }

    public void CheckNote(GameObject CheckNote){
        
        //터치포인트에 들어온 노트 오브젝트를 담음.
        checkNote=CheckNote;
    }

    public void ResetNote(GameObject note){
        //끝점으로간 노트를 리셋
        note.transform.position=startPoint.position;
        note.SetActive(false);
    }
}