using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
public class PlayerJoinRandomRoomScript : MonoBehaviourPunCallbacks
{
    public InputField PlayerNameInput;

    private Dictionary<string, RoomInfo> cachedRoomList;
    private Dictionary<string, GameObject> roomListEntries;
    private Dictionary<int, GameObject> playerListEntries;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayButtonClicked()
    {
        string playerName = PlayerNameInput.text;
        Debug.Log(playerName);

        if (!playerName.Equals(""))
        {
            PhotonNetwork.LocalPlayer.NickName = playerName;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.LogError("Player Name is invalid.");
        }
    }
    public override void OnConnectedToMaster()
    {
        if(PhotonNetwork.IsConnectedAndReady)
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Here");
        string roomName = "Room " + Random.Range(1000, 10000);

        RoomOptions options = new RoomOptions { MaxPlayers = 4};

        PhotonNetwork.CreateRoom(roomName, options, null);
        PhotonNetwork.LoadLevel("SandBox");
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SandBox");
    }
    

}