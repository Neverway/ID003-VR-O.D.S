using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementColliderPosition1 : MonoBehaviour
{
    public Transform playerCenter; // VR Camera Reference
    public GameObject characterController;

    // Update is called once per frame
    void Update()
    {
        characterController.transform.position = new Vector3(playerCenter.localPosition.x, 1.03f, playerCenter.localPosition.z);
    }
}
