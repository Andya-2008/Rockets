using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovePowerup : MonoBehaviour
{
    float moveX=1f;
    float moveY=1f;
    float newSpeed;
    public bool move=true;
    [SerializeField]bool bulletSpeed;
    [SerializeField] bool bulletTime;
    [SerializeField] bool powerTime;
    public bool alreadyGavePowerup;
    [SerializeField] Image myImage;
    [SerializeField] GameObject myText;
    [SerializeField] GameObject myText2;
    bool shrink;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            this.GetComponent<RectTransform>().position += new Vector3(moveX, moveY, 0);
        }
            if(Input.GetKeyDown(KeyCode.L))
        {
            ChangePos();
        }
        ChangeDir();
    }
    public void ChangePos()
    {
        newSpeed = Random.Range(.5f, 2f);
        moveX = newSpeed;
        moveY = newSpeed;
        this.GetComponent<RectTransform>().position = new Vector3(Random.Range(360f,836f), Random.Range(37f,363f),0);
    }
    void ChangeDir()
    {
        if (!alreadyGavePowerup)
        {
            if (!move)
            {
                if (this.GetComponent<RectTransform>().position.x <= 160)
                {
                    myText.SetActive(true);
                    GameObject.Find("PowerupCanvas").GetComponent<PowerupManager>().startTime = Time.time;
                    GameObject.Find("PowerupCanvas").GetComponent<PowerupManager>().alreadySpawned = false;
                    GetComponent<DragPowerup>().enabled = false;
                    shrink = true;
                    alreadyGavePowerup = true;
                    if (bulletSpeed)
                    {
                        GameObject.Find("Rocket1").GetComponent<Shooter>().bulletSpeed += 1000;
                    }
                    if (bulletTime)
                    {
                        GameObject.Find("Rocket1").GetComponent<Shooter>().bulletTime *= .7f;
                    }
                    if (powerTime)
                    {
                        GameObject.Find("Rocket1").GetComponent<RocketPowerup>().powerupTime *= .8f;
                    }
                }
                else if (this.GetComponent<RectTransform>().position.x >= 1700)
                {
                    myText2.SetActive(true);
                    GameObject.Find("PowerupCanvas").GetComponent<PowerupManager>().startTime = Time.time;
                    GameObject.Find("PowerupCanvas").GetComponent<PowerupManager>().alreadySpawned = false;
                    GetComponent<DragPowerup>().enabled = false;
                    shrink = true;
                    alreadyGavePowerup = true;
                    if (bulletSpeed)
                    {
                        GameObject.Find("Rocket2").GetComponent<Shooter>().bulletSpeed += 1000;
                    }
                    if (bulletTime)
                    {
                        GameObject.Find("Rocket2").GetComponent<Shooter>().bulletTime *= .7f;
                    }
                    if (powerTime)
                    {
                        GameObject.Find("Rocket2").GetComponent<RocketPowerup>().powerupTime*=.8f;
                    }

                }

            }
            
        }

        if(this.GetComponent<RectTransform>().position.x>=1080 || this.GetComponent<RectTransform>().position.x <= 50)
        {
            moveX*= -1;
        }
        if (this.GetComponent<RectTransform>().position.y <= 37 || this.GetComponent<RectTransform>().position.y >= 363f)
        {
            moveY *= -1;
        }
        if (shrink)
        {
            move = false;
            myImage.GetComponent<RectTransform>().localScale += new Vector3(-.01f, -.01f, -.01f);
            if (myImage.GetComponent<RectTransform>().localScale.x <= 0)
            {
                shrink = false;
                this.gameObject.SetActive(false);
                myText.SetActive(false);
                myText2.SetActive(false);
                myImage.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
