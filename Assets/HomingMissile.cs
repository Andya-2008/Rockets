using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField] bool Rocket1;
    [SerializeField] bool Rocket2;
    [SerializeField] float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rocket1)
        {
            this.transform.LookAt(GameObject.Find("Rocket2").transform, Vector3.up);
            transform.Translate(transform.up*Time.deltaTime);
        }
        if (Rocket2)
        {
            this.transform.LookAt(GameObject.Find("Rocket1").transform, Vector3.up);
            transform.Translate(transform.up*Time.deltaTime);
        }
    }
}
