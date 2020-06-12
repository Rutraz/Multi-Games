using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private Transform targetFollow;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
        transform.position.x,
       // Mathf.Clamp(targetFollow.position.y, 0f, 10f),
        targetFollow.position.y,
        transform.position.z);
    }
}
