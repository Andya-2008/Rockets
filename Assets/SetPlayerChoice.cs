using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerChoice : MonoBehaviour
{
    [SerializeField] GameObject Head1;
    [SerializeField] GameObject Body1;
    [SerializeField] GameObject LeftThruster1;
    [SerializeField] GameObject RightThruster1;
    [SerializeField] GameObject Head2;
    [SerializeField] GameObject Body2;
    [SerializeField] GameObject LeftThruster2;
    [SerializeField] GameObject RightThruster2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(PlayerPrefs.GetInt("HeadColor1"))
        {
            case 0:
                Head1.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                break;
            case 1:
                Head1.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;
            case 2:
                Head1.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                break;
            case 3:
                Head1.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                break;
        }
        switch(PlayerPrefs.GetInt("BodyColor2"))
        {
            case 0:
                Body1.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                break;
            case 1:
                Body1.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;
            case 2:
                Body1.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                break;
            case 3:
                Body1.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                break;
        }
        switch(PlayerPrefs.GetInt("ThrustersColor2"))
        {
            case 0:
                RightThruster1.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                LeftThruster1.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                break;
            case 1:
                RightThruster1.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                LeftThruster1.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;
            case 2:
                RightThruster1.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                LeftThruster1.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                break;
            case 3:
                RightThruster1.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                LeftThruster1.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                break;
            default:
                Debug.LogError("DisplayColor is not recieving a \"colorNum.\"");
                break;
        }
        switch(PlayerPrefs.GetInt("HeadColor2"))
        {
            case 0:
                Head2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                break;
            case 1:
                Head2.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;
            case 2:
                Head2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                break;
            case 3:
                Head2.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                break;
        }
        switch(PlayerPrefs.GetInt("BodyColor2"))
        {
            case 0:
                Body2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                break;
            case 1:
                Body2.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;
            case 2:
                Body2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                break;
            case 3:
                Body2.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                break;
        }
        switch(PlayerPrefs.GetInt("ThrustersColor2"))
        {
            case 0:
                RightThruster2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                LeftThruster2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                break;
            case 1:
                RightThruster2.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                LeftThruster2.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                break;
            case 2:
                RightThruster2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                LeftThruster2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                break;
            case 3:
                RightThruster2.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                LeftThruster2.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                break;
            default:
                Debug.LogError("DisplayColor is not recieving a \"colorNum.\"");
                break;
        }
    }
}
