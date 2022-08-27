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
    // Start is called before the first frame update
    void Start()
    {
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
        if(Input.GetKeyDown(KeyCode.L))
        {
            Powerup = 0;
            ActivatePowerup();
        }
    }

    void ActivatePowerup()
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
