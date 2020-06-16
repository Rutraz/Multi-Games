using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAsteroid : MonoBehaviour
{

    public GameObject AsteroidPrefab;

     public float timestart;

    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    public float secondsToMaxDifficulty;

    public float minSpawn;
    public float maxSpawn;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
      
        StartCoroutine(asteroidWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     private void spawnEnemy()
    {
        GameObject a = Instantiate(AsteroidPrefab) as GameObject;
       // a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x  ) , screenBounds.y * 2);
        a.transform.position = new Vector2(screenBounds.x*1, Random.Range(screenBounds.y, screenBounds.y*22));
    }

     IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            
            respawnTime = Mathf.Lerp(minSpawn, maxSpawn, GetDifficultyPercent());
           
           
        }


        float GetDifficultyPercent()
        {
            return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);  //vai nos devolver o valor de percentagem entre 0 e 1 da dificuldade desde que começou o jogo
        }
    }
}
