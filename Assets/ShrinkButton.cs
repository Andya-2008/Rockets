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
    float rocketspeed = .15f;
    float startTime;
    [SerializeField] GameObject BackgroundMusic;
    [SerializeField] GameObject MusicButton;
    [SerializeField] GameObject MusicFireCover;
    [SerializeField] Slider VolumeSlider;
    bool alreadyMusic;
    bool alreadyMusicStarted;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shrink)
        {
            if (!alreadyMusic)
            {
                startTime = Time.time;
                alreadyMusic = true;
                PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
                VolumeSlider.interactable = false;
                if (PlayerPrefs.GetString("Music") == "on")
                {
                    GetComponent<AudioSource>().volume *= PlayerPrefs.GetFloat("Volume");
                    GetComponent<AudioSource>().Play();
                }
            }
            moveRocket = true;
            this.GetComponent<RectTransform>().localScale += new Vector3(-.01f, -.01f, -.01f);
            MusicButton.GetComponent<RectTransform>().position += new Vector3(0, 2f, 0);
            if (this.GetComponent<RectTransform>().localScale.x <= 0)
            {

                shrink = false;
                this.GetComponent<Image>().enabled = false;
                
            }
        }
        if (moveRocket)
        {
            
            if (!alreadyMusicStarted && Time.time-startTime>.5f)
            {
                if (PlayerPrefs.GetString("Music") == "on")
                {
                    
                    DontDestroyOnLoad(BackgroundMusic);
                    BackgroundMusic.GetComponent<AudioSource>().volume *= PlayerPrefs.GetFloat("Volume");
                    alreadyMusicStarted = true;
                    BackgroundMusic.SetActive(true);
                    BackgroundMusic.GetComponent<AudioSource>().Play();
                }
                else
                {
                    PlayerPrefs.SetFloat("Volume", 0);
                }
                
            }
            Rocket.GetComponent<RectTransform>().position += new Vector3(0, rocketspeed * 100 * Time.deltaTime, 0);
            rocketspeed += .005f;
            MusicFireCover.SetActive(false);
            MusicButton.GetComponent<RectTransform>().position += new Vector3(0, 3f, 0);
            VolumeSlider.GetComponent<RectTransform>().position += new Vector3(0, 3f, 0);

            if (Time.time - startTime >= 6)
            {
                Debug.Log("Here");
                GameObject.Find("FadeCanvas").GetComponent<FadeImageScript>().Sandbox = true;
            }
        }
        
    }
}