using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{

    float scrollSpeed = -2f;
    Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 10);
        transform.position = startPos + Vector2.up * newPos;
    }
}
