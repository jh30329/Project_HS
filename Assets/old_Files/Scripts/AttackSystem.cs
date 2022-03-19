using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{

    public enum Type { Melee, Range };
    public Type type;
    public int damage;
    public float rate;
    public BoxCollider AtkArea;

    public float Timer;
    public float WaitingTime;

    //public void Def()
    //{
    //    if(type == Type.Melee)
    //    {
    //        StopCoroutine("Swing");
    //        StartCoroutine("Swing");
    //    }
    //}

    private void Start()
    {
        Timer = 0;
        WaitingTime = 0.5f;

    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else if(Timer > WaitingTime)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Timer = 0;
        }
        

    }

    //private void OnTriggerEnter(Collider other)
    //{

    //}

    //IEnumerator Melee()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    gameObject.GetComponent<BoxCollider>().enabled = true;

    //    yield return new WaitForSeconds(0.3f);
    //    gameObject.GetComponent<BoxCollider>().enabled = false;

    //    yield return new WaitForSeconds(0.3f);

    //}
}
