using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Movement : MonoBehaviour
{
    PhotonView photonView;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    Rigidbody rb;
    AudioSource audioSource;
    float offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        photonView = this.GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //photonView.RPC("StartThrusting", RpcTarget.All);
            StartThrusting();
        }
        else
        {
            //photonView.RPC("StopThrusting", RpcTarget.All);
            StopThrusting();
        }
    }

    public void ProcessRotation()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        //photonView.RPC("RPCRotate", RpcTarget.All, angle);
    }
    //[PunRPC]
    public void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }
    //[PunRPC]
    public void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }


    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    }
    /*[PunRPC]
    public void RPCRotate(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }*/
}
