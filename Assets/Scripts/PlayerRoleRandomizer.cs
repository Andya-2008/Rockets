using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerRoleRandomizer : MonoBehaviour
{
    [SerializeField] GameObject Controller1;
    [SerializeField] GameObject Controller2;
    [SerializeField] GameObject Controller3;
    [SerializeField] GameObject Controller4;
    [SerializeField] TextMeshProUGUI RocketName1;
    [SerializeField] TextMeshProUGUI RocketName2;
    [SerializeField] TextMeshProUGUI RocketName3;
    [SerializeField] TextMeshProUGUI RocketName4;
    [SerializeField] Transform BulletInstPos1;
    [SerializeField] Transform BulletInstPos2;
    [SerializeField] Transform BulletInstPos3;
    [SerializeField] Transform BulletInstPos4;
    // Start is called before the first frame update
    void Start()
    {
        
        if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[0].NickName)
        {
            Controller1.SetActive(true);
            Controller2.SetActive(false);
            Controller3.SetActive(false);
            Controller4.SetActive(false);
            RocketName1.text = PhotonNetwork.LocalPlayer.NickName;
            GameObject.Find("ShooterManager").GetComponent<Shooter>().BulletInstPos = BulletInstPos1;

            //GameObject.Find("Rocket1").GetComponent<CollisionHandler>().myController=Controller1;
        }
        if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[1].NickName)
        {
            Controller1.SetActive(false);
            Controller2.SetActive(true);
            Controller3.SetActive(false);
            Controller4.SetActive(false);
            RocketName2.text = PhotonNetwork.LocalPlayer.NickName;
            GameObject.Find("ShooterManager").GetComponent<Shooter>().BulletInstPos = BulletInstPos2;
            //GameObject.Find("Rocket2").GetComponent<CollisionHandler>().myController = Controller2;
        }
        if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[2].NickName)
        {
            Controller1.SetActive(false);
            Controller2.SetActive(false);
            Controller3.SetActive(true);
            Controller4.SetActive(false);
            RocketName3.text = PhotonNetwork.LocalPlayer.NickName;
            GameObject.Find("ShooterManager").GetComponent<Shooter>().BulletInstPos = BulletInstPos3;
            //GameObject.Find("Rocket3").GetComponent<CollisionHandler>().myController = Controller3;
        }
        if (PhotonNetwork.LocalPlayer.NickName == PhotonNetwork.PlayerList[3].NickName)
        {
            Controller1.SetActive(false);
            Controller2.SetActive(false);
            Controller3.SetActive(false);
            Controller4.SetActive(true);
            RocketName4.text = PhotonNetwork.LocalPlayer.NickName;
            GameObject.Find("ShooterManager").GetComponent<Shooter>().BulletInstPos = BulletInstPos4;
            //GameObject.Find("Rocket4").GetComponent<CollisionHandler>().myController = Controller4;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
