using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketMovement : MonoBehaviour
{
    public GameObject obj;

    private Rigidbody2D rb;
    public float speed = 0;

    private float clickStart;
    private bool moreThenOne;


    public GameObject GameFinish;
    bool timerActive = false;

//Time
    public float timestart;
    public Text textBox;
    public GameObject timeLost;

    public GameObject[] counts;
     public float timeBetween = 0.1f; // Time in seconds
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        textBox.text = timestart.ToString("F2");
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
        
        if (timerActive)
        {
            timestart += Time.deltaTime;
            textBox.text = timestart.ToString("F2");
        }




        rb.velocity = new Vector2(0, speed);

        if (Input.GetMouseButtonDown(0))
        {
            clickStart = Time.time;
            speed = 10;
            obj.SetActive(true);
            timerActive = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            clickStart = Time.time;
            speed = 0;
            obj.SetActive(false);
        }
       
       
       
    }

   void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.tag == "Asteroid")
         {
              
            //timeLost.SetActive(true);

             StartCoroutine(Count());


             

         }

          if (other.gameObject.tag == "Moon")
        {
           GameFinish.SetActive(true);
            timerActive = false;
        }
     }
    


public IEnumerator Count() 
     {

           timeLost.SetActive(true);
            timestart++;
            yield return new WaitForSeconds(timeBetween); // Waits for the time set in timeBetween, affected by timeScale.

           
             timeLost.SetActive(false);
     }

}


