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
        targetFollow.position.y,
        transform.position.z);
    }
}
