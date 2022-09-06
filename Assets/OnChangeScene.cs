using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnChangeScene : MonoBehaviour
{
    public void ChangeScene(int sceneNum)
    {
        if(sceneNum==1)
        {
            Debug.Log(3);
            GameObject.Find("FadeCanvas").GetComponent<FadeImageScript>().home = true;
        }
        else if (sceneNum == 2)
        {
            GetComponent<ShrinkButton>().shrink = true;
            PlayerPrefs.SetInt("HeadColor1", GameObject.Find("Buttons1").GetComponent<ButtonLocalScript>().headColorNum);
            PlayerPrefs.SetInt("BodyColor1", GameObject.Find("Buttons1").GetComponent<ButtonLocalScript>().bodyColorNum);
            PlayerPrefs.SetInt("ThrustersColor1", GameObject.Find("Buttons1").GetComponent<ButtonLocalScript>().thrustersColorNum);
            PlayerPrefs.SetInt("HeadColor2", GameObject.Find("Buttons2").GetComponent<ButtonLocalScript>().headColorNum);
            PlayerPrefs.SetInt("BodyColor2", GameObject.Find("Buttons2").GetComponent<ButtonLocalScript>().bodyColorNum);
            PlayerPrefs.SetInt("ThrustersColor2", GameObject.Find("Buttons2").GetComponent<ButtonLocalScript>().thrustersColorNum);
            
        }
        else if(sceneNum==857)
        {
            this.GetComponent<AudioSource>().Play();
            Debug.Log("1");
            GameObject.Find("FadeCanvas").GetComponent<FadeImageScript>().home = true;
            Destroy(GameObject.Find("BackGroundMusic"));
            GameObject.Find("TitleCanvas").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("FadeCanvas").GetComponent<FadeImageScript>().end = true;
        }
    }
}
