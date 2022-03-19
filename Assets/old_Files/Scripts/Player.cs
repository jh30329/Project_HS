using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Rigidbody rigidbody;


    //Move
    Vector3 MoveDir;
    float angle;
    float turnSmoothVelocity;
    public Transform cam;
    public float moveSpeed;
    public float turnSmoothTime = 0.1f;

    //Animation
    private Animator animator;

    //Attack
    bool atkWhile;


    private void Awake()
    {

        // Mouse Lock

        Cursor.lockState = CursorLockMode.Locked;

        // Cursor visible

        Cursor.visible = false;

        
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        //AttackSystem Test = GameObject.Find("AtkCol").GetComponent<AttackSystem>();

    }

    private void FixedUpdate()
    {
        
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

        

        

        MoveDir = new Vector3(x, 0, z).normalized;

        if (MoveDir.magnitude >= 0.1f)
        {
            angle = Mathf.Atan2(MoveDir.x, MoveDir.z);
            angle = Mathf.Rad2Deg * angle;
            angle += cam.eulerAngles.y;

            //캐릭터가 키보드 입력으로 부드럽게 회전하는 공식
            float tAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnSmoothVelocity, turnSmoothTime);
            
            //적용해 주는 구간 쿼터니언 값을 오일러로 변경시켜줌 주의 점은 무조건 tAngle을 써야한다. 그냥 angle 쓰면 스무싱 안먹힘
            transform.rotation = Quaternion.Euler(0f, tAngle, 0f);

            Vector3 moveViewDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            Debug.Log(moveViewDir);

            rigidbody.MovePosition(moveViewDir * moveSpeed * Time.deltaTime + transform.position);


        }

    }
    

    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        animator.SetBool("Walk", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("Walk", false);
    //    }
        
    //}
    
    

}
