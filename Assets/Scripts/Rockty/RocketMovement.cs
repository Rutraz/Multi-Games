using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float speed = 0;

    private float clickStart;
    private bool moreThenOne;



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
            speed = 5;
        }

        if (Input.GetMouseButtonUp(0) && Time.time - clickStart >= 1)
        {
            moreThenOne = true;
            speed = 5;
        }
        if (Input.GetMouseButtonUp(0) && Time.time - clickStart < 1)
        {
            speed = 0;
            moreThenOne = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Astroid")
        {
            speed = -3;

        }
    }

}


