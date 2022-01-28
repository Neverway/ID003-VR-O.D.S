using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTrack : MonoBehaviour
{
    public bool trackingActive = false;
    public GameObject trackingTarget;
    public Vector3 defaultRotation;

    // Update is called once per frame
    public void Update()
    {
        if (trackingActive)
        {
            transform.LookAt(trackingTarget.transform);
        }
        else if (!trackingActive)
        {
            transform.LookAt(trackingTarget.transform);

            //transform.rotation = Quaternion.Euler(defaultRotation);
        }
    }

    public void trackingOff()
    {
        trackingActive = false;
    }
    public void trackingOn()
    {
        trackingActive = true;
    }
}
