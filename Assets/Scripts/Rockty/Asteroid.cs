using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    float speed;

    public float secondsToMaxDifficulty;


    private Rigidbody2D rb;
    private Vector2 screenBounds;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        speed =  Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());   // Mathf.Lerp(minValue, maxValue, percent) se o percent for 0 devovle o minValue e se for 1 devovle maxValue
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

         col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 10 * Time.deltaTime));

        if (transform.position.x <  - screenBounds.x )
        {
           
            Destroy(this.gameObject);
        }
    }

     float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);  //vai nos devolver o valor de percentagem entre 0 e 1 da dificuldade desde que começou o jogo
    }
}
