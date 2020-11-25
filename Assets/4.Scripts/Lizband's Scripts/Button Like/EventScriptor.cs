using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class EventScriptor : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DisconnectFromServer()
    {
        PhotonNetwork.Disconnect();
    }
}
