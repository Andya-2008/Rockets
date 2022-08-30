using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("Music", "on");
        PlayerPrefs.SetInt("TitleCanvasDestroyed", 0);
        DontDestroyOnLoad(GameObject.Find("TitleCanvas"));
        
        PlayerPrefs.SetInt("Rocket1Score",0);
        PlayerPrefs.SetInt("Rocket2Score",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
