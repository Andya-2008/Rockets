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
    [SerializeField] float bulletSpeed;
    float startTime;
    [SerializeField] bool Com;
    [SerializeField] bool Phone;
    public int powerup;
    public bool Nerf;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Nerf)
        {
            Nerf=false;
            bulletSpeed=700;
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
            if(Time.time-startTime>1)
            {
                if(rocket1)
                {
                    if (GameObject.Find("Fixed Joybutton").GetComponent<MyJoybutton>().Pressed)
                    {
                        Shoot();
                    }
                }
                if(rocket2)
                {
                    if (GameObject.Find("Fixed Joybutton (1)").GetComponent<MyJoybutton>().Pressed)
                    {
                        Shoot();
                    }
                }
            }
        }
    }

    private void Shoot()
    {
        if(powerup==0)
        {
            startTime=Time.time;
            GameObject newBullet = Instantiate(Bullet, BulletInstPos);
            //newBullet.GetComponent<Rigidbody>().AddRelativeForce(transform.forward*bulletSpeed);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.up*bulletSpeed);
            newBullet.transform.parent = GameObject.Find("Balls").GetComponent<Transform>();
        }
        else if(powerup==1)
        {
            powerup=0;
            bulletSpeed*=2;
        }
    }
}
