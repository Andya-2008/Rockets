using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShrinkButton : MonoBehaviour
{
    public bool shrink;
    bool moveRocket;
    [SerializeField] GameObject Rocket;
    float rocketspeed=.15f;
    [SerializeField] GameObject FadeImage;
    Color fadeImagecolor;
    float startTime;
    [SerializeField] GameObject BackgroundMusic;
    [SerializeField] GameObject MusicButton;
    // Start is called before the first frame update
    void Start()
    {
        
        fadeImagecolor = Color.white;
        fadeImagecolor.a = 0;
        FadeImage.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(shrink)
        {
            if (PlayerPrefs.GetString("Music") == "on")
            {
                DontDestroyOnLoad(BackgroundMusic);
                BackgroundMusic.SetActive(true);
                BackgroundMusic.GetComponent<AudioSource>().Play();
            }
            FadeImage.SetActive(true);
            moveRocket = true;
            this.GetComponent<RectTransform>().localScale += new Vector3(-.01f,-.01f,-.01f);
            MusicButton.GetComponent<RectTransform>().position += new Vector3(0, 2f, 0);
            if (this.GetComponent<RectTransform>().localScale.x<=0)
            {
                
                shrink = false;
                this.GetComponent<Image>().enabled=false;
                startTime = Time.time;
            }
        }
        if(moveRocket)
        {
            
            Rocket.GetComponent<RectTransform>().position += new Vector3(0,rocketspeed*100*Time.deltaTime,0);
            rocketspeed += .005f;
            MusicButton.GetComponent<RectTransform>().position += new Vector3(0, 2f, 0);
            if (Time.time - startTime >= 5)
            {
                fadeImagecolor.a += .01f; 
                FadeImage.GetComponent<Image>().color = fadeImagecolor;
            }
            if(fadeImagecolor.a>=1.1f)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
