using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class DefaultRoom
{
    public string roomName;
    public int sceneIndex;
    public int roomMaxPlayers;
}

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public List<DefaultRoom> defaultRooms;
    public GameObject JoinUI;
    public GameObject playerTarget;
    public bool serverIsVisible = true;
    public bool serverIsOpen = true;

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("[ID003] : Trying to connect to server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("[ID003] : Connection successful!");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("[ID003] : Joined lobby!");
        JoinUI.SetActive(true);
    }

    public void InitializeRoom(int deafultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[deafultRoomIndex];

        // Load Room
        Destroy(playerTarget);
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);

        // Create Room
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.roomMaxPlayers;
        roomOptions.IsVisible = serverIsVisible;
        roomOptions.IsOpen = serverIsOpen;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.roomName, roomOptions, TypedLobby.Default);
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
