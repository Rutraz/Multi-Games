using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float timestart;
    public Text textBox;

    bool timerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timestart.ToString("F2");

    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timestart += Time.deltaTime;
            textBox.text = timestart.ToString("F2");
        }
        
    }

    public void timerButton()
    {
        timerActive = !timerActive;
    }
}
