using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    //timer vars
    public Slider timerSlider;
    public Text timerText;
    public float gameTime;
    private bool stopTimer;
    public Button startButton;
    //score vars
    public Slider scoreSlider;
    public Text scoreText;
    public int goalScore;

    void startGame()
    {
        stopTimer = false;
        Destroy(startButton.gameObject);
    }

    void Start()
    {
        stopTimer = true;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        scoreSlider.maxValue
        scoreSlider.value = 0;

        startGame();
    }

    void Update()
    {    
        //Game timer begins when startGame()
        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <= 0)
        {
            stopTimer = true;
        }

        if (stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = time;
            
        }

    }
}
