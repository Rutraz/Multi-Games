using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWalk : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    Vector2 targetPosition;

   
    public float speed;


    public float secondsToMaxDifficulty;

    public float timestart;
    public Text textBox;

    bool timerActive = true;

    public GameObject GameOver_Panel;

    public AudioClip Audio;
    AudioSource audioData;

    public float timeBetween = 0.5f; // Time in seconds

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        targetPosition = GetRandomPosition();
        textBox.text = timestart.ToString("F2");
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    // Update is called once per frame
    void Update()
    {

        if (timerActive)
        {
            timestart += Time.deltaTime;
            textBox.text = timestart.ToString("F2");
        }

        if ((Vector2)transform.position != targetPosition)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }
    }

Vector2 GetRandomPosition()
    {
        float randomX = UnityEngine.Random.Range(minX, maxX);
        float randomY = UnityEngine.Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Slime")
        {
            timerActive = false;
            GameOver_Panel.SetActive(true);

             StartCoroutine(TakeHit()); //starts de coroutine
           
            
        } 
    }

    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);  //vai nos devolver o valor de percentagem entre 0 e 1 da dificuldade desde que começou o jogo
    }

    public IEnumerator TakeHit() // active and disactivate de number of secs lost
     {

           audioData.PlayOneShot(Audio, 1F);
        
           yield return new WaitForSeconds(timeBetween); // Waits for the time set in timeBetween, affected by timeScale.


           audioData.Stop();
     }
}
