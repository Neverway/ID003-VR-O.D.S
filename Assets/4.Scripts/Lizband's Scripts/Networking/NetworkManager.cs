using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public byte serverMaxPlayers = 4;
    public bool serverIsVisible = true;
    public bool serverIsOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    // Update is called once per frame
    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("[ID003] : Trying to connect to server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("[ID003] : Connection successful!");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = serverMaxPlayers;
        roomOptions.IsVisible = serverIsVisible;
        roomOptions.IsOpen = serverIsOpen;

        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("[ID003] : Joined room!");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("[ID003] : A new player has connected!");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
