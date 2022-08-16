using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject Text1GameOver;
    [SerializeField] GameObject Text2GameOver;
    
    [SerializeField] GameObject Text1;
    [SerializeField] GameObject Text2;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject button;
    bool GameOverProcessStarted;
    float startTime;
    bool finalGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOverProcessStarted && Time.time-startTime>2)
        {
            int RandomMap=Random.Range(2,7);
            GetComponent<OnChangeScene>().ChangeScene(RandomMap);
        }
        if(finalGameOver && Time.time-startTime>2)
        {
            button.SetActive(true);
            GameObject.Find("ScoreTextManager").GetComponent<ScoreText>().Lock=true;
            Text1GameOver.GetComponent<GrowAndShrink>().StopAnimation();
            Text2GameOver.GetComponent<GrowAndShrink>().StopAnimation();
            PlayerPrefs.SetInt("Rocket1Score",0);
            PlayerPrefs.SetInt("Rocket2Score",0);
            
        }
    }

    public void GameOverStart(int winner)
    {
        if (winner==1)
        {
            if(PlayerPrefs.GetInt("Rocket1Score")>=4)
            {
                GameObject.Find("ScoreTextManager").GetComponent<ScoreText>().rocket1.text = "5";
                finalGameOver=true;
                startTime=Time.time;
                canvas.GetComponent<Canvas>().enabled=true;
                Text1GameOver.SetActive(true);
                Text2GameOver.SetActive(false);
            }
            else
            {
                startTime=Time.time;
                GameOverProcessStarted=true;
                Text1.SetActive(true);
                Text2.SetActive(false);
            }
        }
        else if (winner==2)
        {
            if(PlayerPrefs.GetInt("Rocket2Score")>=4)
            {
                GameObject.Find("ScoreTextManager").GetComponent<ScoreText>().rocket2.text = "5";
                finalGameOver=true;
                startTime=Time.time;
                canvas.GetComponent<Canvas>().enabled=true;
                Text1GameOver.SetActive(false);
                Text2GameOver.SetActive(true);
            }
            else
            {
                startTime=Time.time;
                GameOverProcessStarted=true;
                Text1.SetActive(false);
                Text2.SetActive(true);
            }
        }
    }
}
