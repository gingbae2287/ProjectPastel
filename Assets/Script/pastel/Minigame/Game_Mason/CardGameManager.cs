using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;    //생성할 카드 오브젝트프리팹
    [SerializeField] UI_CraftingGauge craftingGauge;
    static int cardPairs=8;    //총 카드 쌍의 수
    int matchingCount; //맞춘 카드 쌍의 수
    int winCount=6;  //승리 조건(매칭쌍 갯수)
    Card[] cardArray=new Card[cardPairs*2];   //생성한 오브젝트의 card 스크립트들 할당
    bool[] isMatching=new bool[cardPairs*2];  //카드가 맞춰진 상태인가
    [SerializeField] Sprite[] spriteList=new Sprite[cardPairs];   //카드에 들어갈 이미지
    //bool[] _isSpriteUesd=new bool[_cardPairs];  //해당 스프라이트가 쓰여졌는가 (랜덤함수중복 없에기위해 사용)
    //쓰여졌는지 판단하고 랜덤을 다시 돌리는건 비효율적==>이론상 무한루프도 가능 (확률희박하지만)
    //랜덤한 두 인덱스를 뽑아 자리 바꾸기 함수를 만들어 여러번 돌리자
    int[] indexArray=new int[cardPairs*2];    //정수배열 0부터 각수가 2개씩 존재 (스프라이트 짝을위해)
    bool gaming;
    bool clickCard;    //카드 클릭 딜레이를 위해

    Card selectedCard;  //선택된 카드 임시 저장

    void Start(){
        gaming=false;
        for(int i=0;i<cardPairs*2;i++){
            //카드 생성
            GameObject card=Instantiate(cardPrefab, transform.position, Quaternion.identity);
            card.transform.SetParent(transform);
            cardArray[i]=card.GetComponent<Card>();
            isMatching[i]=false;
            indexArray[i]=i/2;
            //card.SetActive(false);
        }

    }
    void Update(){
        if(gaming && Input.GetMouseButtonDown(0)){

        }
    }

    
    public void Init(){
        gaming=false;
        clickCard=false;
        matchingCount=0;
        selectedCard=null;
        craftingGauge.MaxGauge=cardPairs;
        craftingGauge.GaugeUpdate(0);
        for(int i=0;i<cardPairs*2;i++) cardArray[i].InitCard();
    }
    public void GameStart(){
        gaming=true;
        clickCard=false;
        matchingCount=0;
        selectedCard=null;
        SuffleArray(indexArray);   //정수배열 섞기
        //카드 이미지 랜덤으로 할당. 각 스프라이트 2개씩 (cardNumber도 스프라이트랑 같이 할당)
        for(int i=0;i<cardPairs*2;i++){
            cardArray[i].ChangeSprite(spriteList[indexArray[i]]);
            cardArray[i].CardNumber=indexArray[i];
        }

        craftingGauge.MaxGauge=cardPairs; //성공 게이지 업데이트
        craftingGauge.GaugeUpdate(0);
        
    }
    public void GameStop(){
        //게임 실행x
        gaming=false;
        for(int i=0;i<cardPairs*2;i++) cardArray[i].InitCard();
    }
    public void ClickCard(Card card){
        if(!gaming) return;
        //카드 클릭시 호출
        if(clickCard) return;
        if(selectedCard==card) return; //같은카드 두번 누를시
        clickCard=true;

        StartCoroutine("CardClickDelay");   //카드 클릭딜레이 부분

        //클릭위치 레이부터 쏘기
        //레이 쏘려면 camera 오브젝트 사용해야함.
        /*
        new Vector3
        RaycastHit hit;
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);

        if(P)
        
        */
        //버튼으로구현
        card.UpsetCard();
        //카드 하나 클릭시
        if(selectedCard==null){
            //카드 정보 가져옴. 0.5초 뒤집는 애니메이션. 그동안 클릭 불가
            selectedCard=card;
        }
        
        //카드 두개 클릭시
        else{
            StartCoroutine("CompairCard",card);
        }
        
    }

    //카드 클릭시 딜레이
    IEnumerator CardClickDelay(){
        yield return new WaitForSeconds(0.5f);
        clickCard=false;
    }
    IEnumerator CompairCard(Card card){
        //하나가 뒤집혔을때 새로 뒤집으면 작동. 짝이맞으면 뒤집히는시간 0.5초만 클릭불가맞춘 카드짝 ++ 뒤집힌 카드 클릭x, 짝이 안맞으면 1초후 다시 뒤집힘 그동안 클릭불가)
        if(card.CardNumber==selectedCard.CardNumber)
        {
            card.IsMatching=true;   //해당카드 짝맞춤 표시
            selectedCard.IsMatching=true;  
            matchingCount++;   //
            craftingGauge.GaugeUpdate(matchingCount);
            if(matchingCount>=winCount)    WinGame();  //게임 승리
            yield return null;
        }
        else{   //카드가 다르면
            StopCoroutine("CardClickDelay");    //해당 코루틴에서 _clickCard가 변하는 오류?를 막기위해 stop
            clickCard=true;
            yield return new WaitForSeconds(1f);    //1초 딜레이후
            clickCard=false;
            card.UpsetCard();   //카드 다시 뒤집기
            selectedCard.UpsetCard();
            
        }

        selectedCard=null;
    }

    void WinGame(){
        //게임 승리 함수
    }



    //배열 섞기
    void SuffleArray(int[] Array){
        for(int i=0;i<Array.Length;i++){
            int randomIdx=Random.Range(0,Array.Length);
            int tmpInt=Array[i];
            Array[i]=Array[randomIdx];
            Array[randomIdx]=tmpInt;
        }
    }
}