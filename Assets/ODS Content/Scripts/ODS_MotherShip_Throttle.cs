using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ODS_MotherShip_Throttle : MonoBehaviour
{

    [Header ("Forward")]
    public float[] forwardThrottleSpeeds;
    public GameObject[] forwardThrottleDials;
    private int currentForwardThrottle;

    [Header ("Steering")]
    public float[] steeringThrottleSpeeds;
    public GameObject[] steeringThrottleDials;
    public int currentSteeringThrottle;


    public Rigidbody motherShipRoot;
    public bool acceptingInput;
    public Color throttleActiveColor;
    public Color throttleInctiveColor;

    // Start is called before the first frame update
    void Start()
    {
        currentForwardThrottle = 0;
        currentSteeringThrottle = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Forward
        motherShipRoot.velocity = new Vector3(motherShipRoot.velocity.x, motherShipRoot.velocity.y, forwardThrottleSpeeds[currentForwardThrottle]);
        for (int i = 0; i < forwardThrottleDials.Length; i++)
        {
            forwardThrottleDials[i].GetComponent<Image>().color = throttleInctiveColor;
            if (i <= currentForwardThrottle)
            {
                forwardThrottleDials[i].GetComponent<Image>().color = throttleActiveColor;
            }
        }

        // Steering
        motherShipRoot.velocity = new Vector3(steeringThrottleSpeeds[currentSteeringThrottle], motherShipRoot.velocity.y, motherShipRoot.velocity.z);
        for (int i = 0; i < steeringThrottleDials.Length; i++)
        {
            steeringThrottleDials[i].GetComponent<Image>().color = throttleInctiveColor;
        }
        steeringThrottleDials[currentSteeringThrottle].GetComponent<Image>().color = throttleActiveColor;
    }

    public void ThrottleIncrease()
    {
        if (currentForwardThrottle + 1 <= forwardThrottleSpeeds.Length - 1 && acceptingInput)
        {
            currentForwardThrottle += 1;
        }
    }

    public void ThrottleDecrease()
    {
        if (currentForwardThrottle - 1 >= 0 && acceptingInput)
        {
            currentForwardThrottle -= 1;
        }
    }

    public void RightSteeringIncrease()
    {
        if (currentSteeringThrottle + 1 <= steeringThrottleSpeeds.Length - 1 && acceptingInput)
        {
            currentSteeringThrottle += 1;
        }
    }

    public void LeftSteeringIncrease()
    {
        if (currentSteeringThrottle - 1 >= 0 && acceptingInput)
        {
            currentSteeringThrottle -= 1;
        }
    }

    public void StopAllEngines()
    {
        acceptingInput = false;
        currentForwardThrottle = 0;
        currentSteeringThrottle = 2;
    }
}
