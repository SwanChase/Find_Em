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
    public static int score;

    void startGame()
    {
        stopTimer = false;
        Destroy(startButton.gameObject);
    }

    void Start()
    {
        //timer
        stopTimer = true;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        //score
        score = 0;
        scoreSlider.maxValue = goalScore;
        scoreSlider.value = score;
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
            scoreText.GetComponent<Text>().text = score.ToString();
            scoreSlider.value = score;
        }

        if (score > goalScore)
        {
            scoreSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
        }
    }
}
