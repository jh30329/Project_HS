using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D CursorTex;

    void Start()
    {
        Cursor.SetCursor(CursorTex, Vector2.zero, CursorMode.ForceSoftware);
    }


    void Update()
    {
        
    }
}
