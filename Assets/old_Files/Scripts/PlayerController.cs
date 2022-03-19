using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    //public UnityEvent Test;
    public Rigidbody rigidbody;
    public float speed = 1.0f;
    public float DashSpeed = 3.0f;
    private bool canDash = false;
    private float checkRun = 0.5f;
    public GameObject Test;
    Vector3 MoveDir;
    float angle;

    float atkDelay;

    public float turnSmoothTime = 0.1f;
    public float gravityValue = -1.0f;
    public Transform cam;

    private bool isAttack;
    bool mAtk;
    bool matkReady;

    public bool isDelay;
    public bool isDashDelay;
    public float delayTime;
    public float DashdelayTime = 1.0f;

    float timer = 0f;


    float turnSmoothVelocity;
    

    //Animator animator;

    private void Awake()
    {
        isAttack = false;
    }

    void Start()
    {

        rigidbody.GetComponent<Rigidbody>();

        //animator = GetComponent<Animator>();

        // Mouse Lock

        Cursor.lockState = CursorLockMode.Locked;

        // Cursor visible

        Cursor.visible = false;

        isDelay = false;
        isDashDelay = false;
        //delayTime = 2f;


    }


    private void Move(float DashSpeed)
    {
        transform.Translate(Vector3.forward * DashSpeed * Time.deltaTime); //moveSpeed의 속도로 전방 돌진
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        MoveDir = new Vector3(x, 0, z).normalized;

        //if (isAttack == true) return;
        if (isAttack == false)
        {

            if (MoveDir.magnitude >= 0.1f)
            {
                angle = Mathf.Atan2(MoveDir.x, MoveDir.z);
                angle = Mathf.Rad2Deg * angle;
                angle += cam.eulerAngles.y;
                float tAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, tAngle, 0f);

                Vector3 moveViewDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

                rigidbody.MovePosition(moveViewDir * speed * Time.deltaTime + transform.position);


            }

        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }


        //if (Input.GetKey("space"))
        //{
        //    canDash = true;
        //    print("Spece Key down");

        //    Move(40.0f);
        //}

        //if (Input.GetKeyUp("space"))
        //{
        //    canDash = false;
        //    print("Spece Key Up");
        //}
        

        //if (canDash == true)
        //{
        //    Move(40.0f);
        //    StartCoroutine("CountDashDelay");
        //}
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (isDelay == false)

            {

                isAttack = true;
                StartCoroutine("CountAttackDelay");

            }

            else
            {
                Debug.Log("Delay");
            }


        }

        if (Input.GetKeyDown("space"))
        {

            if (isDashDelay == false)

            {

                canDash = true;
                print("Spece Key down");

                Move(300.0f);

            }

            else
            {
                Debug.Log("Delay");
                canDash = false;
            }


        }
    }

    IEnumerator CountAttackDelay()
    {
        isDelay = true;

        GameObject obj = Instantiate(Test, transform.position, Quaternion.identity);
        //obj.transform.parent = gameObject.transform;
        //obj.transform.position = rigidbody.transform.position;
        obj.transform.rotation = gameObject.transform.rotation;


        yield return new WaitForSeconds(1.0f);
        isAttack = false;
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }

    IEnumerator CountDashDelay()
    {
        isDashDelay = true;
        
        yield return new WaitForSeconds(1.0f);
        canDash = false;
        yield return new WaitForSeconds(DashdelayTime);
        isDashDelay = false;
    }
    //void Attack()
    //{
    //    Debug.Log("Damage");
    //}

}
