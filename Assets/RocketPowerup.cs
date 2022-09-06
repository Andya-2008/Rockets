using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPowerup : MonoBehaviour
{

    [SerializeField]bool Rocket1;
    [SerializeField]bool Rocket2;

    public int Powerup;
    [SerializeField] GameObject bigBullet;
    [SerializeField] float bulletSpeed;
    public Transform BulletInstPos;
    public float powerupTime;
    public bool powerupActive=true;
    public float startTime;
    public GameObject powerupUIBackground1;
    public GameObject powerupUIBackground2;
    [SerializeField] GameObject HomingMissilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        powerupUIBackground1 = GameObject.Find("Fixed JoybuttonBackground1");
        powerupUIBackground2 = GameObject.Find("Fixed JoybuttonBackground2");
        
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
        if(Powerup==1)
        {
            Boost();
        }
        /*if(Powerup==2)
        {
            HomingMissile();
        }*/
    }
    void BigBullet()
    {
        GameObject newBullet = Instantiate(bigBullet, BulletInstPos);
        //newBullet.GetComponent<Rigidbody>().AddRelativeForce(transform.forward*bulletSpeed);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.up * bulletSpeed);
        newBullet.transform.parent = GameObject.Find("Balls").GetComponent<Transform>();
    }
    void Boost()
    {
        GetComponent<Rigidbody>().AddRelativeForce(2500*Vector3.up);
    }
    /*void HomingMissile()
    {
        GameObject newBullet = Instantiate(HomingMissilePrefab, BulletInstPos);
        newBullet.transform.parent = GameObject.Find("Balls").GetComponent<Transform>();
    }*/
}
