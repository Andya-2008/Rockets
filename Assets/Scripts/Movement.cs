using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;
    float joystickX;
    float joystickY;
    float joystickX2;
    float joystickY2;
    Rigidbody rb;
    AudioSource audioSource;
    public bool rocket1;
    public bool rocket2;
    [SerializeField] bool Com;
    [SerializeField] bool Phone;
    bool resetRot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        joystickX = GameObject.Find("Fixed Joystick").GetComponent<Joystick>().Direction.x;
        joystickY = GameObject.Find("Fixed Joystick").GetComponent<Joystick>().Direction.y;
        joystickX2 = GameObject.Find("Fixed Joystick (1)").GetComponent<Joystick>().Direction.x;
        joystickY2 = GameObject.Find("Fixed Joystick (1)").GetComponent<Joystick>().Direction.y;
        ProcessThrust();
        ProcessRotation();
        //Debug.Log(Mathf.Asin(joystickY/(Mathf.Sqrt(joystickX*joystickX+joystickY*joystickY))) * 180/Mathf.PI + "; " + Mathf.Acos(joystickX/(Mathf.Sqrt(joystickX*joystickX+joystickY*joystickY))) * 180/Mathf.PI);
    }

    void ProcessThrust()
    {
        if(Com)
        {
            if (rocket1) 
            {
                if (Input.GetKey(KeyCode.W))
                {
                    rb.AddRelativeForce(Vector3.up * mainThrust* Time.deltaTime);
                    if (!audioSource.isPlaying) 
                        if (!audioSource.isPlaying)
                        {
                            audioSource.PlayOneShot(mainEngine);
                        }
                    if (!mainEngineParticles.isPlaying)
                    {
                        mainEngineParticles.Play();
                    }
                }
                else
                {
                    audioSource.Stop();
                    mainEngineParticles.Stop();
                }
            }
            if (rocket2)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
                    if (!audioSource.isPlaying)
                        if (!audioSource.isPlaying)
                        {
                            audioSource.PlayOneShot(mainEngine);
                        }
                    if (!mainEngineParticles.isPlaying)
                    {
                        mainEngineParticles.Play();
                    }
                }
                else
                {
                    audioSource.Stop();
                    mainEngineParticles.Stop();
                }
            }
        }
        if(Phone)
        {
            if (rocket1) 
            {
                if (Mathf.Sqrt(joystickX*joystickX+joystickY*joystickY)!=0)
                {
                    rb.AddRelativeForce(Vector3.up * Mathf.Sqrt(joystickX*joystickX+joystickY*joystickY) * mainThrust * Time.deltaTime);
                    if (!audioSource.isPlaying) 
                        if (!audioSource.isPlaying)
                        {
                            audioSource.PlayOneShot(mainEngine);
                        }
                    if (!mainEngineParticles.isPlaying)
                    {
                        mainEngineParticles.Play();
                    }
                }
                else
                {
                    audioSource.Stop();
                    mainEngineParticles.Stop();
                }
            }
            if (rocket2)
            {
                if (Mathf.Sqrt(joystickX2*joystickX2+joystickY2*joystickY2)!=0)
                {
                    rb.AddRelativeForce(Vector3.up * Mathf.Sqrt(joystickX2*joystickX2+joystickY2*joystickY2) * mainThrust * Time.deltaTime);
                    if (!audioSource.isPlaying) 
                        if (!audioSource.isPlaying)
                        {
                            audioSource.PlayOneShot(mainEngine);
                        }
                    if (!mainEngineParticles.isPlaying)
                    {
                        mainEngineParticles.Play();
                    }
                }
                else
                {
                    audioSource.Stop();
                    mainEngineParticles.Stop();
                }
            }
        }
    }

    void ProcessRotation()
    {
        if(Com)
        {
            if(rocket1)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    ApplyRotation(rotationThrust);
                    if (!rightThrusterParticles.isPlaying)
                    {
                        rightThrusterParticles.Play();
                    }
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    ApplyRotation(-rotationThrust);
                    if (!leftThrusterParticles.isPlaying)
                    {
                        leftThrusterParticles.Play();
                    }
                }
                else
                {
                    rightThrusterParticles.Stop();
                    leftThrusterParticles.Stop();
                }
            }
            if(rocket2)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    ApplyRotation(rotationThrust);
                    if (!rightThrusterParticles.isPlaying)
                    {
                        rightThrusterParticles.Play();
                    }
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    ApplyRotation(-rotationThrust);
                    if (!leftThrusterParticles.isPlaying)
                    {
                        leftThrusterParticles.Play();
                    }
                }
                else
                {
                    rightThrusterParticles.Stop();
                    leftThrusterParticles.Stop();
                }
            }
        }
        if(Phone)
        {
            if(rocket1)
            {
                if(Mathf.Asin(joystickY/(Mathf.Sqrt(joystickX*joystickX+joystickY*joystickY))) * 180/Mathf.PI>0)
                {
                    if(resetRot)
                    {
                        resetRot=false;
                        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                    }
                    transform.rotation=Quaternion.Euler(new Vector3(this.transform.rotation.x,this.transform.rotation.y,Mathf.Acos(joystickX/(Mathf.Sqrt(joystickX*joystickX+joystickY*joystickY))) * 180/Mathf.PI-90));
                }
                else if(Mathf.Asin(joystickY/(Mathf.Sqrt(joystickX*joystickX+joystickY*joystickY))) * 180/Mathf.PI<0)
                {
                    transform.rotation=Quaternion.Euler(new Vector3(this.transform.rotation.x,this.transform.rotation.y,Mathf.Acos(joystickX/(Mathf.Sqrt(joystickX*joystickX+joystickY*joystickY))) * -180/Mathf.PI-90));
                }
                else
                {
                    resetRot=true;
                }
            }
            if(rocket2)
            {
                if(Mathf.Asin(joystickY2/(Mathf.Sqrt(joystickX2*joystickX2+joystickY2*joystickY2))) * 180/Mathf.PI>0)
                {
                    transform.rotation=Quaternion.Euler(new Vector3(this.transform.rotation.x,this.transform.rotation.y,Mathf.Acos(joystickX2/(Mathf.Sqrt(joystickX2*joystickX2+joystickY2*joystickY2))) * 180/Mathf.PI-90));
                }
                else if(Mathf.Asin(joystickY2/(Mathf.Sqrt(joystickX2*joystickX2+joystickY2*joystickY2))) * 180/Mathf.PI<0)
                {
                    transform.rotation=Quaternion.Euler(new Vector3(this.transform.rotation.x,this.transform.rotation.y,Mathf.Acos(joystickX2/(Mathf.Sqrt(joystickX2*joystickX2+joystickY2*joystickY2))) * -180/Mathf.PI-90));
                }
            }
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    }
}