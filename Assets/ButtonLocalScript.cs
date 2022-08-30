using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonLocalScript : MonoBehaviour
{
    [SerializeField] GameObject Head;
    [SerializeField] GameObject Body;
    [SerializeField] GameObject LeftThruster;
    [SerializeField] GameObject RightThruster;
    public int headColorNum = 0;
    public int bodyColorNum = 0;
    public int thrustersColorNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPressed(int buttonNum)
    {
        if(buttonNum==0)
        {
            headColorNum+=1;
            DisplayColor("Head", headColorNum);
        }
        if(buttonNum==1)
        {
            headColorNum-=1;
            DisplayColor("Head", headColorNum);
        }
        if(buttonNum==2)
        {
            bodyColorNum+=1;
            DisplayColor("Body", bodyColorNum);
        }
        if(buttonNum==3)
        {
            bodyColorNum-=1;
            DisplayColor("Body", bodyColorNum);
        }
        if(buttonNum==4)
        {
            thrustersColorNum+=1;
            DisplayColor("Thrusters", thrustersColorNum);
        }
        if(buttonNum==5)
        {
            thrustersColorNum-=1;
            DisplayColor("Thrusters", thrustersColorNum);
        }
    }
    public void DisplayColor(string part, int colorNum)
    {
        Debug.Log(colorNum);
        switch(part)
        {
            case "Head":
                switch(colorNum)
                {
                    case -1:
                        Head.GetComponent<RawImage>().color=new Color32(251,255,0,255);
                        headColorNum=3;
                        break;
                    case 0:
                        Head.GetComponent<RawImage>().color=new Color32(255,0,0,255);
                        break;
                    case 1:
                        Head.GetComponent<RawImage>().color = new Color32(0,255,0,255);
                        break;
                    case 2:
                        Head.GetComponent<RawImage>().color=new Color32(0,0,0,255);
                        break;
                    case 3:
                        Head.GetComponent<RawImage>().color = new Color32(251,255,0,255);
                        break;
                    case 4:
                        Head.GetComponent<RawImage>().color=new Color32(255,0,0,255);
                        headColorNum=0;
                        break;
                    default:
                        Debug.LogError("DisplayColor is not recieving a \"colorNum.\"");
                        break;
                }
                break;
            case "Body":
                switch(colorNum)
                {
                    case -1:
                        Body.GetComponent<RawImage>().color=new Color32(251,255,0,255);
                        bodyColorNum=3;
                        break;
                    case 0:
                        Body.GetComponent<RawImage>().color=new Color32(255,0,0,255);
                        break;
                    case 1:
                        Body.GetComponent<RawImage>().color = new Color32(0,255,0,255);
                        break;
                    case 2:
                        Body.GetComponent<RawImage>().color=new Color32(0,0,0,255);
                        break;
                    case 3:
                        Body.GetComponent<RawImage>().color = new Color32(251,255,0,255);
                        break;
                    case 4:
                        Body.GetComponent<RawImage>().color=new Color32(255,0,0,255);
                        bodyColorNum=0;
                        break;
                    default:
                        Debug.LogError("DisplayColor is not recieving a \"colorNum.\"");
                        break;
                }
                break;
                case "Thrusters":
                    switch(colorNum)
                    {
                        case -1:
                            RightThruster.GetComponent<RawImage>().color=new Color32(251,255,0,255);
                            LeftThruster.GetComponent<RawImage>().color=new Color32(251,255,0,255);
                            thrustersColorNum=3;
                            break;
                        case 0:
                            RightThruster.GetComponent<RawImage>().color=new Color32(255,0,0,255);
                            LeftThruster.GetComponent<RawImage>().color=new Color32(255,0,0,255);
                            break;
                        case 1:
                            RightThruster.GetComponent<RawImage>().color=new Color32(0,255,0,255);
                            LeftThruster.GetComponent<RawImage>().color=new Color32(0,255,0,255);
                            break;
                        case 2:
                            RightThruster.GetComponent<RawImage>().color=new Color32(0,0,0,255);
                            LeftThruster.GetComponent<RawImage>().color=new Color32(0,0,0,255);
                            break;
                        case 3:
                            RightThruster.GetComponent<RawImage>().color = new Color32(251,255,0,255);
                            LeftThruster.GetComponent<RawImage>().color = new Color32(251,255,0,255);
                            break;
                        case 4:
                            RightThruster.GetComponent<RawImage>().color=new Color32(255,0,0,255);
                            LeftThruster.GetComponent<RawImage>().color=new Color32(255,0,0,255);
                            thrustersColorNum=0;
                            break;
                        default:
                            Debug.LogError("DisplayColor is not recieving a \"colorNum.\"");
                            break;
                    }
                    break;

            default:
                Debug.LogError("DisplayColor is not recieving a \"part.\"");
                break;
        }
    }
}
