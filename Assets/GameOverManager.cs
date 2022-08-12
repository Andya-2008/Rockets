using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject Text1;
    [SerializeField] GameObject Text2;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject button;
    bool GameOverProcessStarted;
    float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOverProcessStarted && Time.time-startTime>2)
        {
            button.SetActive(true);
            Text1.GetComponent<GrowAndShrink>().StopAnimation();
            Text2.GetComponent<GrowAndShrink>().StopAnimation();
            GameOverProcessStarted=false;
        }
    }

    public void GameOverStart(int winner)
    {
        startTime=Time.time;
        GameOverProcessStarted=true;
        canvas.GetComponent<Canvas>().enabled=true;
        if(winner==1)
        {
            Text1.SetActive(true);
            Text2.SetActive(false);
        }
        if(winner==2)
        {
            Text1.SetActive(false);
            Text2.SetActive(true);
        }
    }
}
