using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerupScript : MonoBehaviour
{
    public bool Powerup1;
    public bool Powerup2;
    public bool Powerup3;
    public bool Powerup4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Powerup1)
        {
            Powerup1 = false;
            Debug.Log("Hi");
        }
    }
}
