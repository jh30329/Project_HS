using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PCMouseMove_Fix : MonoBehaviour
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

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                //클릭 하였을 시
                agent.SetDestination(hit.point);
            }

        }
        
    }
    

}
