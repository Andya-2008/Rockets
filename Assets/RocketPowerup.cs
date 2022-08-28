using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPowerup : MonoBehaviour
{

    [SerializeField]bool Rocket1;
    [SerializeField]bool Rocket2;

    int Powerup;
    [SerializeField] GameObject bigBullet;
    [SerializeField] float bulletSpeed;
    public Transform BulletInstPos;
    [SerializeField] float powerupTime;
    public bool powerupActive=true;
    public float startTime;
    public GameObject powerupUIBackground1;
    public GameObject powerupUIBackground2;
    // Start is called before the first frame update
    void Start()
    {
        powerupUIBackground1 = GameObject.Find("Fixed JoybuttonBackground1");
        powerupUIBackground2 = GameObject.Find("Fixed JoybuttonBackground2");
        //Comment this out
        Powerup = 0;
        if(Rocket1)
        {
            Powerup = PlayerPrefs.GetInt("Player1Powerup");
        }
        else if(Rocket2)
        {
            Powerup = PlayerPrefs.GetInt("Player2Powerup");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-startTime >= powerupTime && !powerupActive)
        {
            powerupActive = true;
            if(Rocket1)
            {
                powerupUIBackground1.SetActive(true);
            }
            if (Rocket2)
            {
                powerupUIBackground2.SetActive(true);
            }
        }
    }

    public void ActivatePowerup()
    {
        if(Powerup==0)
        {
            BigBullet();
        }
    }
    void BigBullet()
    {
        GameObject newBullet = Instantiate(bigBullet, BulletInstPos);
        //newBullet.GetComponent<Rigidbody>().AddRelativeForce(transform.forward*bulletSpeed);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.up * bulletSpeed);
        newBullet.transform.parent = GameObject.Find("Balls").GetComponent<Transform>();
    }
}
