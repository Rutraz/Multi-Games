using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    private Transform centerBackground;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= centerBackground.position.y + 20.40835f)
        {
            centerBackground.position = new Vector2(centerBackground.position.x, transform.position.y + 20.40835f);
        } 
        else if (transform.position.y >= centerBackground.position.y - 20.40835f)
        {
            centerBackground.position = new Vector2(centerBackground.position.x, transform.position.y - 20.40835f);
        }
    }
}
