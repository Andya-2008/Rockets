using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI rocket1;
    [SerializeField] TextMeshProUGUI rocket2;
    // Start is called before the first frame update
    void Start()
    {
        rocket1.text = PlayerPrefs.GetInt("Rocket1Score").ToString();
        rocket2.text = PlayerPrefs.GetInt("Rocket2Score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.K))
        {
            rocket1.text="0";
            rocket2.text="0";
            PlayerPrefs.SetInt("Rocket1Score",0);
            PlayerPrefs.SetInt("Rocket2Score",0);
        }*/
    }
    
}
