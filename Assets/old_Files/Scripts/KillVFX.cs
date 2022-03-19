using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVFX : MonoBehaviour
{
    public float KillTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, KillTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
