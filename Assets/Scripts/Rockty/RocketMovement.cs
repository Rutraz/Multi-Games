using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class RocketMovement : MonoBehaviour
{
    public GameObject obj;

    private Rigidbody2D rb;
    public float speed = 10;

    private float clickStart;
 
    private  int test = 0;

    bool timerActive = false;

    public float timestart; //Time


    public Text textBox;
    public GameObject GameFinish;
    public GameObject timeLost;

     public float timeBetween = 0.1f; // Time in seconds
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        textBox.text = timestart.ToString("F2");
    }


    void Update()
    {
        //Activate Time
        if (timerActive)
        {
            timestart += Time.deltaTime;
            textBox.text = timestart.ToString("F2");
        }


        rb.velocity = new Vector2(0, speed);

        //Everytime the mouse is click or screen touch moves foward
        if (Input.GetMouseButtonDown(0))
        {
             
            //So começa o jogo quando carrega pela primeira vez no ecran
            if(test == 0){
                Time.timeScale = 1;
                timerActive = true;
                test++;
            }
            clickStart = Time.time;
            speed = 10;
            obj.SetActive(true);// "animation"
            
        }

        //when we stop clicking the rocket stop
        if (Input.GetMouseButtonUp(0))
        {
            clickStart = Time.time;
            speed = 0;
            obj.SetActive(false); // "Cancel de Animation"
        }
        
    }

   void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.tag == "Asteroid") // when Rocket collid with an asteroid
         {
              
             StartCoroutine(TakeHit()); //starts de coroutine

         }

          if (other.gameObject.tag == "Moon") // when Rocket collid with the moon
        {
           GameFinish.SetActive(true);
           timerActive = false;
           Time.timeScale = 0; //para tudo
          // EditorApplication.isPaused = true; // pause everything
        }
     }
    


public IEnumerator TakeHit() // active and disactivate de number of secs lost
     {

           timeLost.SetActive(true);
           timestart++;
           yield return new WaitForSeconds(timeBetween); // Waits for the time set in timeBetween, affected by timeScale.
           timeLost.SetActive(false);
     }

}


