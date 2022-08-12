using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] bool Player1Bool;
    [SerializeField] bool Player2Bool;
    [SerializeField] bool Player3Bool;
    [SerializeField] bool Player4Bool;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    [SerializeField] GameObject Player3;
    [SerializeField] GameObject Player4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

/*
    // Update is called once per frame
    void Update()
    {
        if(Player1Bool)
        {
            Player1.GetComponent<Movement>().ProcessRotation();
            Player1.GetComponent<Movement>().ProcessThrust();
        }
        if(Player2Bool)
        {
            Player2.GetComponent<Movement>().ProcessRotation();
            Player2.GetComponent<Movement>().ProcessThrust();
        }
        if(Player3Bool)
        {
            Player3.GetComponent<Movement>().ProcessRotation();
            Player3.GetComponent<Movement>().ProcessThrust();
        }
        if(Player4Bool)
        {
            Player4.GetComponent<Movement>().ProcessRotation();
            Player4.GetComponent<Movement>().ProcessThrust();
        }
        
    }
    */
}
