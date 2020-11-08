using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSeat : MonoBehaviour
{
    public Transform seatTarget;
    public GameObject playerTarget;
    public GameObject playerTarget1;
    public GameObject playerTarget2;
    public bool isOccupied;

    // Update is called once per frame
    void Update()
    {
        if (isOccupied)
        {
            playerTarget.transform.position = new Vector3(seatTarget.position.x, seatTarget.position.y, seatTarget.position.z);
            playerTarget1.transform.position = new Vector3(seatTarget.position.x, seatTarget.position.y, seatTarget.position.z);
            playerTarget2.transform.position = new Vector3(seatTarget.position.x, seatTarget.position.y, seatTarget.position.z);
        }

        if (!isOccupied)
        {

        }
    }

    public void ToggleSeat()
    {
        if (isOccupied)
        {
            isOccupied = false;
        }
        else if (!isOccupied)
        {
            isOccupied = true;
        }
    }
}
