using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    float speed;

    public float secondsToMaxDifficulty;


    private Rigidbody2D rb;
    private Vector2 screenBounds;


    bool moveAllowed;
    Collider2D col;

    void Start()
    {
        speed =  Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());   // Mathf.Lerp(minValue, maxValue, percent) se o percent for 0 devovle o minValue e se for 1 devovle maxValue

        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Drag and Drop
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    moveAllowed = true;
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }


        if (transform.position.y <  - screenBounds.y )
        {
           
            Destroy(this.gameObject);
        }
    }

    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);  //vai nos devolver o valor de percentagem entre 0 e 1 da dificuldade desde que começou o jogo
    }
}
