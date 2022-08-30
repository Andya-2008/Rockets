using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicbutton : MonoBehaviour
{
    [SerializeField] GameObject OnText;
    [SerializeField] GameObject OffText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MusicPressed()
    {
        Debug.Log("Button pressed");
        if(PlayerPrefs.GetString("Music") == "off")
        {
            PlayerPrefs.SetString("Music", "on");
            OnText.SetActive(true);
            OffText.SetActive(false);
        }
        
        else if(PlayerPrefs.GetString("Music") == "on")
        {
            PlayerPrefs.SetString("Music", "off");
            OnText.SetActive(false);
            OffText.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("Music", "off");
            OnText.SetActive(false);
            OffText.SetActive(true);
        }
    }
}
