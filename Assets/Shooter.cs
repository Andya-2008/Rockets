using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    public Transform BulletInstPos;
    [SerializeField] bool rocket1;
    [SerializeField] bool rocket2;
    public float bulletSpeed;
    float startTime;
    [SerializeField] bool Com;
    [SerializeField] bool Phone;
    public int powerup;
    public bool Nerf;
    float origBulletSpeed;
    public float bulletTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        origBulletSpeed=bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Nerf)
        {
            Nerf=false;
            bulletSpeed=origBulletSpeed;
        }
        if(Com)
        {
            if(Time.time-startTime>1)
            {
                if(rocket1)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        Shoot();
                    }
                }
                if(rocket2)
                {
                    if (Input.GetKey(KeyCode.RightControl))
                    {
                        Shoot();
                    }
                }
            }
        }
        if(Phone)
        {
            if (Time.time - startTime > bulletTime)
            {
                if (rocket1)
                {
                    if (GameObject.Find("Fixed Joybutton").GetComponent<MyJoybutton>().Pressed)
                    {
                        if (this.GetComponent<RocketPowerup>().powerupActive)
                        {
                            this.GetComponent<RocketPowerup>().ActivatePowerup();
                            this.GetComponent<RocketPowerup>().powerupActive = false;
                            this.GetComponent<RocketPowerup>().startTime = Time.time;
                            this.GetComponent<RocketPowerup>().powerupUIBackground1.SetActive(false);
                            startTime = Time.time;
                        }
                        else
                        {
                            Shoot();
                        }
                    }
                }
                if (rocket2)
                {
                    if (GameObject.Find("Fixed Joybutton (1)").GetComponent<MyJoybutton>().Pressed)
                    {
                        if (this.GetComponent<RocketPowerup>().powerupActive)
                        {
                            this.GetComponent<RocketPowerup>().ActivatePowerup();
                            this.GetComponent<RocketPowerup>().powerupActive = false;
                            this.GetComponent<RocketPowerup>().startTime = Time.time;
                            this.GetComponent<RocketPowerup>().powerupUIBackground2.SetActive(false);
                            startTime = Time.time;
                        }
                        else
                        {
                            Shoot();
                        }   
                    }
                }
            }
        }
    }

    private void Shoot()
    {
        startTime = Time.time;
        GameObject newBullet = Instantiate(Bullet, BulletInstPos);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.up * bulletSpeed);
        newBullet.transform.parent = GameObject.Find("Balls").GetComponent<Transform>();
    }
}
