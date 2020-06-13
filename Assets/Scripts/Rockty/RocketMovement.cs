using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketMovement : MonoBehaviour
{
    public GameObject obj;

    private Rigidbody2D rb;
    public float speed = 0;

    private float clickStart;
    private bool moreThenOne;

    public GameObject GameFinish;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


   /* public void Move()
    {
        speed++;
        rb.velocity = new Vector2(0, speed);
        speed = 0;
    }
    */

    void Update()
    {
        
        rb.velocity = new Vector2(0, speed);

        if (Input.GetMouseButtonDown(0))
        {
            clickStart = Time.time;
            speed = 10;
            obj.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            clickStart = Time.time;
            speed = 0;
            obj.SetActive(false);
        }
       
       
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Astroid")
        {
          
        } 

        if (collision.tag == "Moon")
        {
           GameFinish.SetActive(true);
        }
        
    }

}


