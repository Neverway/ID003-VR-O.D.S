using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerBodyPosFix : MonoBehaviour
{
    public Transform playerCenter; // VR Camera Reference
    public CapsuleCollider characterController;

    // Update is called once per frame
    void Update()
    {
        characterController.center = new Vector3(playerCenter.localPosition.x, 1.03f, playerCenter.localPosition.z);
    }
}
