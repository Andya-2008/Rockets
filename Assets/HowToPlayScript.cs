using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayScript : MonoBehaviour
{
    [SerializeField] GameObject iPanel;
    [SerializeField] GameObject howtoplayButton;
    [SerializeField] GameObject exitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPressButton(int state)
    {
        if(state==0)
        {
            howtoplayButton.SetActive(false);
            iPanel.SetActive(true);
            exitButton.SetActive(true);
        }
        if(state==1)
        {
            iPanel.SetActive(false);
            howtoplayButton.SetActive(true);
            exitButton.SetActive(false);
        }
    }
}
