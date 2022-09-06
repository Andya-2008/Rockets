using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    [SerializeField]bool level4;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!level4)
        {
            if (period <= Mathf.Epsilon) { return; }
            float cycles = Time.time / period;  // continually growing over time

            const float tau = Mathf.PI * 2;  // constant value of 6.283
            float rawSinWave = Mathf.Sin(cycles * tau);  // going from -1 to 1

            movementFactor = (rawSinWave + 1f) / 2f;   // recalculated to go from 0 to 1 so its cleaner

            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;
        }
        else
        {
            this.GetComponent<AnchorGameObject>().enabled = false;
            if(movementVector.x>0)
            {
                this.transform.position = new Vector3(this.transform.position.x+period, this.transform.position.y, this.transform.position.z);
            }
            else if(movementVector.x<0)
            {
                this.transform.position = new Vector3(this.transform.position.x-period, this.transform.position.y, this.transform.position.z);
            }
            
        }
    }
}
