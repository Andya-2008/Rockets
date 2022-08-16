using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAddForce : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    GameObject balls;
    // Start is called before the first frame update
    void Awake()
    {
        balls = GameObject.Find("Balls");
        this.GetComponent<Rigidbody>().AddRelativeForce(transform.right*bulletSpeed);
        this.transform.parent = balls.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
