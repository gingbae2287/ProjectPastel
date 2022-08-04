using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    // Start is called before the first frame update   
    public static int HP;
    public float speed=5f;
    public float jumpPower=50f;
    public float rotateSpeed=5f;
    public float throwPower=3f;
    Rigidbody rigidbody;
    Animator animator;
    Vector3 movement;
    GameObject playerEquipPoint;
    float horizontalMove;
    float verticalMove;
    bool isJumping;
    int Jumpcount=1;
    bool isPicking;
    bool Throwing;

    //---라이프 사이클------
    //GameObject ground;
    void Awake(){
        // 최초 로딩때 단 한번 실행
        //여러 기본값 설정
        rigidbody=GetComponent<Rigidbody> ();
        animator=GetComponent<Animator>();

        HP=100;

        playerEquipPoint=GameObject.FindGameObjectWithTag("EquipPoint");

        //ground=GameObject.FindGameObjectWithTag("ground");

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
        
        Turn();
        Aim();

        /*if(Input.GetButtonUp("Fire2") && isPicking){
            Drop();
        }*/
        if(Input.GetMouseButtonUp(0)&& isPicking){
            Drop();
            Throwing=false;
        }

        //Aim();

    }

    //점프
    
    // Update is called once per frame
    void Update()   // 키입력
    {
        //한 프레임마다 실행, 주요 로직, 최대 60프레임까지 실행

        //move
        horizontalMove=Input.GetAxisRaw("Horizontal");
        verticalMove=Input.GetAxisRaw("Vertical");

        //jump
        if(Input.GetButton("Jump")) {
            if (isJumping) return;
            isJumping=true;
            //rigidbody.AddForce(Vector3.up*jumpPower,ForceMode.Impulse);
        }

        //item

        

        //Throwing
        if(Input.GetMouseButtonDown(0)&& isPicking){
            Throwing=true;

        }

        

        AnimationUpdate();
        
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
        if(Jumpcount<=0) return;


        rigidbody.AddForce(Vector3.up*jumpPower,ForceMode.Impulse);
        Jumpcount--;
    }
    
    void AnimationUpdate(){
        if(horizontalMove==0 && verticalMove==0) animator.SetBool("isRunning", false);
        else animator.SetBool("isRunning",true);
        if(isJumping) animator.SetBool("isJumping", true);
        else animator.SetBool("isJumping", false);

        
        if(Throwing) animator.SetBool("Throwing", true);
        else animator.SetBool("Throwing", false);
        
        
    }

    void Turn(){
        if(horizontalMove==0&& verticalMove==0) return;
        Quaternion newRotation=Quaternion.LookRotation(movement);
        rigidbody.rotation=Quaternion.Slerp(rigidbody.rotation, newRotation,rotateSpeed*Time.deltaTime);

    }

    void OnCollisionEnter(Collision other){
        //if (isJumping==false) return;
        if (other.gameObject.tag=="ground"){
            isJumping=false;
            Jumpcount=1;
        }

    }

    ///////////////////////item ////////////////

    public void Pickup(GameObject item){
        SetEquip(item, true);
        isPicking=true;

        
    }


    void SetEquip(GameObject item, bool isEquip){

        Collider[] itemColliders=item.GetComponents<Collider> ();
        Rigidbody itemRigidbody=item.GetComponent<Rigidbody> ();

        foreach(Collider itemCollider in itemColliders){
            itemCollider.enabled= !isEquip; //모든 컴포넌트는 enabled 속성으로 키고끄기가능
        }
        itemRigidbody.isKinematic=isEquip;  //isKinematic 스크립트에 의해서만 움직임
    }

    void Drop(){ //FixedUpdate에 넣어야함
        

        GameObject item=playerEquipPoint.GetComponentInChildren<Rigidbody>().gameObject;
        Rigidbody itemrigidbody=item.GetComponent<Rigidbody>();
        SetEquip(item,false);

        playerEquipPoint.transform.DetachChildren();    //종속관계 떼어놓기
        

        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        float rayLength=500f;
        int floorMask=LayerMask.GetMask("Floor");
        Vector3 throwAngle;

        if(Physics.Raycast(ray, out rayHit, rayLength, floorMask)){
            
            /*
            Debug.DrawRay(playerEquipPoint.transform.position, rayHit.point, Color.red);

            Vector3 playerToMouse=rayHit.point - playerEquipPoint.transform.position;
            playerToMouse.y=0f;
            Quaternion newRotation=Quaternion.LookRotation(playerToMouse);
            rigidbody.MoveRotation(newRotation);
            */
            throwAngle=rayHit.point-playerEquipPoint.transform.position;
        }
        else{
            throwAngle=transform.forward*0f;
        }

        throwAngle.y=2f;
        itemrigidbody.AddForce(throwAngle*throwPower,ForceMode.Impulse);

        isPicking=false;
    }

    void Aim(){
        if(!Throwing) return;

        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        float rayLength=500f;
        int floorMask=LayerMask.GetMask("Floor");

         if(Physics.Raycast(ray, out rayHit, rayLength, floorMask)){
             Debug.DrawRay(playerEquipPoint.transform.position, rayHit.point, Color.red);
            Vector3 playerToMouse=rayHit.point - playerEquipPoint.transform.position;
            playerToMouse.y=0f;
            Quaternion newRotation=Quaternion.LookRotation(playerToMouse);
            rigidbody.MoveRotation(newRotation);

         }

    }
}

