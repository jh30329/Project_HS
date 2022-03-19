using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{

    public GameObject Test;
    
    public bool isDelay;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isDelay == false)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true; // or false

                Debug.Log("Normal Attack");

                StartCoroutine("Atktest");
            }
        }

        
    }


    IEnumerator Atktest()
    {
        isDelay = true;

        GameObject obj = Instantiate(Test, transform.position, Quaternion.identity);

        obj.transform.rotation = gameObject.transform.rotation;
        
        yield return new WaitForSeconds(1.0f);

        gameObject.GetComponent<BoxCollider>().enabled = false;

        //GameObject obj = Instantiate.
        isDelay = false;


        yield break;
    }

}