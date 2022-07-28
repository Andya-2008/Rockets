using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LagThing : MonoBehaviour
{
    Rigidbody rigidBody;
    private void Start()
    {
         rigidBody = this.GetComponent<Rigidbody>();
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rigidBody.position);
            stream.SendNext(rigidBody.rotation);
            stream.SendNext(rigidBody.velocity);
        }
        else
        {
            rigidBody.position = (Vector3)stream.ReceiveNext();
            rigidBody.rotation = (Quaternion)stream.ReceiveNext();
            rigidBody.velocity = (Vector3)stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            rigidBody.position += rigidBody.velocity * lag;
        }
    }
    void Update()
    {
        
    }
}
