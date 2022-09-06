using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeImageScript : MonoBehaviour
{
    [SerializeField] GameObject FadeImage;
    Color fadeImagecolor;
    bool start=true;
    public bool end;
    public bool home;
    public bool Sandbox;
    // Start is called before the first frame update
    void Start()
    {
        fadeImagecolor = Color.white;
        start = true;
        FadeImage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            fadeImagecolor.a -= .03f;
            FadeImage.GetComponent<Image>().color = fadeImagecolor;
            if (fadeImagecolor.a <= 0)
            {
                FadeImage.SetActive(false);
                start = false;
            }
        }
        if (end)
        {
            FadeImage.SetActive(true);
            fadeImagecolor.a += .03f;
            FadeImage.GetComponent<Image>().color = fadeImagecolor;
            if (fadeImagecolor.a >= 1f)
            {
                end = false;
                int sceneNum = Random.Range(2, 10);
                SceneManager.LoadScene(sceneNum);
            }
        }
        if (home)
        {
            FadeImage.SetActive(true);
            fadeImagecolor.a += .03f;
            FadeImage.GetComponent<Image>().color = fadeImagecolor;
            if (fadeImagecolor.a >= 1f)
            {
                end = false;
                SceneManager.LoadScene(1);
            }
        }
        if (Sandbox)
        {
            FadeImage.SetActive(true);
            fadeImagecolor.a += .03f;
            FadeImage.GetComponent<Image>().color = fadeImagecolor;
            if (fadeImagecolor.a >= 1f)
            {
                end = false;
                SceneManager.LoadScene(2);
            }
        }
    }
    
}
