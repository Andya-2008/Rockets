using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] List<GameObject> powerupList = new List<GameObject>();
    public float startTime;
    [SerializeField]bool initialTimeCheck;
    [SerializeField] Transform spawnPos;
    int powerUpNum;
    GameObject nextPowerup;
    public bool active;
    [SerializeField] GameObject OrigUnInteract;
    [SerializeField] GameObject BulletSpeedUnInteract;
    // Start is called before the first frame update
    void Start()
    {
        startTime=Time.time;  
        //spawnPos.position = new Vector3(0,0,0);      
    }

    // Update is called once per frame
    void Update()
    {
        ProcessPowerups();
    }
    
    void ProcessPowerups()
    {
        if(Time.time-startTime>7 && !active)
        {
            
            if(initialTimeCheck)
            {
                spawnPos.position = new Vector3(Random.Range(-21,9), Random.Range(2, 12), 0);
                Instantiate(nextPowerup, spawnPos.position, Quaternion.identity);
                
            }
            
            powerUpNum=Random.Range(0,powerupList.Count);
            nextPowerup = powerupList[powerUpNum];
            active=true;
            SetPowerUpUIActive(powerUpNum+1);
        }
        
    }
    void SetPowerUpUIActive(int Powerup)
    {
        if(!initialTimeCheck)
        {
            active=false;
            initialTimeCheck=true;
        }
        if(Powerup==1)
        {
            BulletSpeedUnInteract.SetActive(true);
            OrigUnInteract.SetActive(false);
        }
        if(Powerup==2)
        {
            BulletSpeedUnInteract.SetActive(false);
            OrigUnInteract.SetActive(true);
        }
    }
}