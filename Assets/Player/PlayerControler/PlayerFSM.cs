using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public enum State
    {
        Idle,
        IdleBoring,
        Move,
        Dash,
        Attack,
        Dead,
    }
    //idle상태가 기본 상태
    public State currentState = State.Idle;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        ChangeState(State.Idle);
    }


    void ChangeState(State newState)
    {
        if (currentState == newState)
        {
            return;
        }
    }

    void Update()
    {
        updatePlayerFSM();
    }

    private void updatePlayerFSM()
    {
        switch (currentState)
        {
            case State.Idle:

                break;

            case State.IdleBoring:

                break;

            case State.Move:

                if (Input.GetMouseButton(1))
                {

                    Debug.Log("Mouse 1");

                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        agent.SetDestination(hit.point);
                    }

                    Debug.Log("Move");
                }
                
                break;

            case State.Dash:

                break;

            case State.Attack:

                break;

            case State.Dead:

                break;
        }
    }
}
