using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPowerup : MonoBehaviour
{
    bool stillActive;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stillActive && Time.time-startTime>5)
        {
            stillActive=false;
            this.GetComponent<Shooter>().Nerf=true;
        }
    }
    public void GrabbedPowerup(int powerUpType)
    {
        GameObject.Find("PowerupManager").GetComponent<PowerupManager>().startTime=Time.time;
        GameObject.Find("PowerupManager").GetComponent<PowerupManager>().active=false;
        stillActive=true;
        startTime=Time.time;
        //Bulletspeed=1
        this.GetComponent<Shooter>().powerup = powerUpType;
    }
}
