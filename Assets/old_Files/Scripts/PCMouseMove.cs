using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PCMouseMove : MonoBehaviour
{
    private Camera camera;

    private bool isMove;
    private Vector3 destination;

    private NavMeshAgent agent;
    

    private void Awake()
    {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        
    }
    

    void Start()
    {

    }



    private void SetDestination(Vector3 dest)
    {
        destination = dest;
        isMove = true;
    }
    
    
    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }

        Move();
        
    }

    private void Move()
    {
        if (isMove)
        {
            if (Vector3.Distance(destination, transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }
            var dir = destination - transform.position;
            transform.forward = dir; // 추가 
            transform.position += dir.normalized * Time.deltaTime * 8f;
            
        }
    }

}
