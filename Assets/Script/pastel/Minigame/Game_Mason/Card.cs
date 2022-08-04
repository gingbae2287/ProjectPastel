using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Sprite _imageBack;
    Sprite _imageFront;
    Image _currentImage;
    bool _isUpset;  //뒤집혔는지 확인
    bool _isMatching; //맞춰진 상태인지 확인
    public bool IsMatching{get{return _isMatching;} set{_isMatching=value;}}
    int _cardNumber;    //카드의 이미지가 같으면 이 숫자도 같음. 이숫자로 같은 카드인지 비교
    public int CardNumber{get{return _cardNumber;} set{_cardNumber=value;}}
    CardGameManager _cardGameManager;

    void Start(){
        _isUpset=false;
        _isMatching=false;
        _currentImage=GetComponent<Image>();
        _currentImage.sprite=_imageBack;
        _cardGameManager=transform.parent.gameObject.GetComponent<CardGameManager>();
    }
    public void InitCard(){
        _isMatching=false;
        _isUpset=false;
        _currentImage.sprite=_imageBack;
    }
    public void ChangeSprite(Sprite sprite){
        _imageFront=sprite;     //게임시작시 랜덤으로 스프라이트 할당
    }

    //카드 뒤집는 함수( manager에서 호출)
    public void UpsetCard(){
        if(!_isUpset) {
            _isUpset=true;
            _currentImage.sprite=_imageFront;
        }
        else if(_isUpset) {
            _isUpset=false;
            _currentImage.sprite=_imageBack;
        }
    }

    public void Bt_ClickCard(){    //카드 클릭했을때 버튼으로 호출
        if(_isMatching) return; //맞춰진 상태면 클릭 x
        _cardGameManager.ClickCard(this);
    
    }

}