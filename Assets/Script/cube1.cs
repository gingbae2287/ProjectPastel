using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube1 : MonoBehaviour
{
    public float speed=5f;
    public float jumpPower=50f;
    Rigidbody rigidbody;
    Animator animator;
    Vector3 movement;
    float horizontalMove;
    float verticalMove;
    bool isJumping;

    //---라이프 사이클------
    void Awake(){
        // 최초 로딩때 단 한번 실행
        //여러 기본값 설정
        rigidbody=GetComponent<Rigidbody> ();
        animator=GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //update 사이클 진입 전 실행, 여러 기본값 설정 및 여러번 실행가능
    }

    void FixedUpdate(){ // 물리효과
        //한 고정프레임마다 실행
        //물리, 리지드 바디에대한 로직, 정확한 물리 시뮬레이팅
        //높은 cpu 부하

        Run();
        Jump();

    }

    //점프
    
    // Update is called once per frame
    void Update()   // 키입력
    {
        //한 프레임마다 실행, 주요 로직, 최대 60프레임까지 실행
        horizontalMove=Input.GetAxisRaw("Horizontal");
        verticalMove=Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Jump")) isJumping=true;
        
    }
    void OnDestroy(){
        
    }
////////////action 함수들/////////////
    void Run(){
        movement.Set(horizontalMove,0,verticalMove);
        movement=movement.normalized*speed*Time.deltaTime;
        //normalized = vector의 합? 모든방향을 합친 하나의 방향과 크기
        // Time.deltaTime 프레임 보정시간

        rigidbody.MovePosition(transform.position+movement);
        // transform.position현재 오브젝트 위치
    }

    void Jump(){
        if(!isJumping) return;

        rigidbody.AddForce(Vector3.up*jumpPower,ForceMode.Impulse);
        isJumping=false;
    }
    
    void AnimationUpdate(){
        if(horizontalMove==0 && verticalMove==0) animator.SetBool("isRunning", false);
        else animator.SetBool("isRunning",true);
        
    }
}
