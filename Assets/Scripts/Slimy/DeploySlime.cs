using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DeploySlime : MonoBehaviour
{
    public GameObject slimePrefab;

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
      
        StartCoroutine(slimeWave());
    }

    void  Update() 
    {
        timestart += Time.deltaTime;
    }


    private void spawnEnemy()
    {
        GameObject a = Instantiate(slimePrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x  ) , screenBounds.y * 2);
    }

    IEnumerator slimeWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            
            respawnTime = Mathf.Lerp(minSpawn, maxSpawn, GetDifficultyPercent());
            UnityEngine.Debug.Log(Mathf.Round(timestart));
           
        }


        float GetDifficultyPercent()
        {
            return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);  //vai nos devolver o valor de percentagem entre 0 e 1 da dificuldade desde que começou o jogo
        }
    }
    
}
