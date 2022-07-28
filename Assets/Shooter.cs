using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] float bulletSpeed = 2f;
    public Transform BulletInstPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(Bullet, BulletInstPos.position, Quaternion.identity);
        //Bullet.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * bulletSpeed);
        /*Player1.GetComponent<Shooter>().enabled = true;
        Player2.GetComponent<Shooter>().enabled = true;
        Player3.GetComponent<Shooter>().enabled = true;
        Player1.GetComponent<Shooter>().enabled = true;*/
    }
}
