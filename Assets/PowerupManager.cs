using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] List<GameObject> powerupList = new List<GameObject>();
    public float startTime;
    bool initialTimeCheck;
    [SerializeField] Transform spawnPos;
    int powerUpNum;
    GameObject nextPowerup;
    public bool active;
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
                active=true;
                spawnPos.position = new Vector3(Random.Range(-21,9), Random.Range(2, 14), 0);
                Instantiate(nextPowerup, spawnPos.position, Quaternion.identity);
                
            }
            else
            {
                initialTimeCheck=true;
            }
            powerUpNum=Random.Range(0,powerupList.Count);
            nextPowerup = powerupList[powerUpNum]; 
            //Put startTime=Time.time later when player touches
        }
        
    }
}