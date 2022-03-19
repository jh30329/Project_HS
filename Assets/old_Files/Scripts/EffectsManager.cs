using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{

    public GameObject VFX00;
    
    public bool isDelay;
    public float delayTime;

    public float Timer;
    public float WaitingTime;

    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("CountAttackDelay");

        }
    }

    //void VFXtest()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        StartCoroutine("CountAttackDelay");

    //    }
    //}

    IEnumerator CountAttackDelay()
    {
        isDelay = true;

        GameObject Slash = Instantiate(VFX00, transform.position, Quaternion.identity);
        Slash.transform.rotation = gameObject.transform.rotation;

        Debug.Log("VFX");


        //yield return new WaitForSeconds(0.2f);
        //isAttack = false;
        yield return new WaitForSeconds(0.5f);
        isDelay = false;
    }
}
