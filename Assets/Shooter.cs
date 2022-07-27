using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] bool Player1Bool;
    [SerializeField] bool Player2Bool;
    [SerializeField] bool Player3Bool;
    [SerializeField] bool Player4Bool;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    [SerializeField] GameObject Player3;
    [SerializeField] GameObject Player4;
    [SerializeField] GameObject Bullet;
    [SerializeField] float bulletSpeed = 2f;
    [SerializeField] GameObject BulletInstPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        
        
        GameObject newBullet = Instantiate(Bullet, BulletInstPos.transform.position, Quaternion.identity);
        Bullet.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * bulletSpeed);
        /*Player1.GetComponent<Shooter>().enabled = true;
        Player2.GetComponent<Shooter>().enabled = true;
        Player3.GetComponent<Shooter>().enabled = true;
        Player1.GetComponent<Shooter>().enabled = true;*/
    }
}
