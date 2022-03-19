using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    public GameObject Test;
    public GameObject Test2;

    bool isWalk = false;
    bool isAtk = false;

    public bool isDelay;

    //bool Atk = false;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isAtk = true;

            //agent.transform.position = new Vector3

            if (isDelay == false)
            {
                Debug.Log("Mouse 0");

                gameObject.GetComponent<BoxCollider>().enabled = true; // or false

                Debug.Log("Normal Attack");

                StartCoroutine("Atktest");
                StartCoroutine("MoveStop");
            }
            
            //Invoke("Test", 1.0f);
        }

        else if (Input.GetMouseButton (1) )
        {
            isAtk = false;

            Debug.Log("Mouse 1");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
            }


        }


    }

    IEnumerator MoveStop()
    {
        isAtk = true;

        Debug.Log("Move Stop");

        agent.ResetPath();

        yield return new WaitForSeconds(1.0f);

        yield break;
    }

    IEnumerator Atktest()
    {
        isDelay = true;

        Debug.Log("Atk");

        GameObject obj = Instantiate(Test, transform.position, Quaternion.identity);

        obj.transform.rotation = gameObject.transform.rotation;

        yield return new WaitForSeconds(0.3f);

        gameObject.GetComponent<BoxCollider>().enabled = false;
            
        //GameObject obj = Instantiate.
        isDelay = false;


        yield break;
    }
    //IEnumerator Atktest2()
    //{
    //    isDelay = true;

    //    Debug.Log("Atk2");

    //    GameObject obj = Instantiate(Test2, transform.position, Quaternion.identity);

    //    obj.transform.rotation = gameObject.transform.rotation;

    //    yield return new WaitForSeconds(0.6f);

    //    gameObject.GetComponent<BoxCollider>().enabled = false;

    //    //GameObject obj = Instantiate.
    //    isDelay = false;


    //    yield break;
    //}
}
