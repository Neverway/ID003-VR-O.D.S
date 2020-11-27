using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterManagerTriggerBased : MonoBehaviour
{
    public GameObject fighterShip;
    public GameObject fighterRoot;
    public float fighterHealth;
    public float fighterFuel;
    public int upgradedLasersID;

    // Engine Stuff
    public float takeOffDistance;
    public float stepSpeed;
    public bool ignition;
    public bool takeOff;
    public bool dock;
    public GameObject jetEffect;

    // Joystick Controls
    public GameObject joystickPivot;
    public float pivotIdleX;
    public float pivotIdleY;
    public float pivotIdleZ;

    public float fighterTiltForwardLimit = -0.12f;
    public float fighterTiltBackwardLimit = 0.12f;
    public float fighterTiltLeftLimit = 0.1f;
    public float fighterTiltRightLimit = 0.1f;
    public float joystickSensitivity = 1f;
    public float joystickDeadzone = 0.5f;

    public bool tiltingUp;
    public bool tiltingDown;
    public bool tiltingLeft;
    public bool tiltingRight;

    public void Start()
    {
        pivotIdleX = joystickPivot.transform.rotation.x;
        pivotIdleY = joystickPivot.transform.rotation.y;
        pivotIdleZ = joystickPivot.transform.rotation.z;
    }


    private void Update()
    {
        // Flight controls
        if (ignition)
        {
            // Tilt Up
            if (tiltingUp)
            {
                if (fighterShip.transform.localRotation.z >= fighterTiltForwardLimit)
                {
                    Quaternion localRotation = Quaternion.Euler(0f, 0f, fighterShip.transform.rotation.z - joystickSensitivity);
                    fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                    Debug.Log("FTilt");
                }
                if (fighterShip.transform.localRotation.z <= fighterTiltForwardLimit)
                {
                    Debug.Log("F");
                    fighterShip.transform.position = new Vector3(fighterShip.transform.position.x, fighterShip.transform.position.y + stepSpeed, fighterShip.transform.position.z);
                }
            }


            // Tilt Down
            if (tiltingDown)
            {
                if (fighterShip.transform.rotation.z <= fighterTiltBackwardLimit)
                {
                    Quaternion localRotation = Quaternion.Euler(0f, 0f, fighterShip.transform.rotation.z + joystickSensitivity);
                    fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                    Debug.Log("BTilt");
                }
                if (fighterShip.transform.localRotation.z >= fighterTiltBackwardLimit)
                {
                    Debug.Log("B");
                    fighterShip.transform.position = new Vector3(fighterShip.transform.position.x, fighterShip.transform.position.y - stepSpeed, fighterShip.transform.position.z);
                }
            }


            // Tilt Right
            if (tiltingRight)
            {
                if (fighterShip.transform.localRotation.x <= fighterTiltRightLimit)
                {
                    Quaternion localRotation = Quaternion.Euler(fighterShip.transform.rotation.x + joystickSensitivity, 0f, 0f);
                    fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                    Debug.Log("RTilt");
                }
                if (fighterShip.transform.localRotation.x >= fighterTiltRightLimit)
                {
                    Debug.Log("R");
                    fighterShip.transform.position = new Vector3(fighterShip.transform.position.x, fighterShip.transform.position.y, fighterShip.transform.position.z + stepSpeed);
                }
            }


            // Tilt Left
            if (tiltingLeft)
            {
                if (fighterShip.transform.localRotation.x >= fighterTiltLeftLimit)
                {
                    Quaternion localRotation = Quaternion.Euler(fighterShip.transform.rotation.x - joystickSensitivity, 0f, 0f);
                    fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                    Debug.Log("LTilt");
                }
                if (fighterShip.transform.localRotation.x <= fighterTiltLeftLimit)
                {
                    Debug.Log("L");
                    fighterShip.transform.position = new Vector3(fighterShip.transform.position.x, fighterShip.transform.position.y, fighterShip.transform.position.z - stepSpeed);
                }
            }

            // Returning tilt
            // Return Verticle
            if (!tiltingUp && !tiltingDown)
            {
                //if (fighterShip.transform.localRotation.z > 0.1 && fighterShip.transform.localRotation.z < -0.1)
                //{
                    if (fighterShip.transform.localRotation.z > 0)
                    {
                        Quaternion localRotation = Quaternion.Euler(0f, 0f, fighterShip.transform.rotation.z - joystickSensitivity);
                        fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                    }
                    if (fighterShip.transform.localRotation.z < 0)
                    {
                        Quaternion localRotation = Quaternion.Euler(0f, 0f, fighterShip.transform.rotation.z + joystickSensitivity);
                        fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                    }
                //}
            }
            // Return Horizontal
            if (!tiltingLeft && !tiltingRight)
            {
                //if (fighterShip.transform.localRotation.x > 0.1 && fighterShip.transform.localRotation.x < -0.1)
                //{
                    if (fighterShip.transform.localRotation.x > 0)
                    {
                        Quaternion localRotation = Quaternion.Euler(fighterShip.transform.rotation.x - joystickSensitivity, 0f, 0f);
                        fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                        
                    }
                    if (fighterShip.transform.localRotation.x < 0)
                    {
                        Quaternion localRotation = Quaternion.Euler(fighterShip.transform.rotation.x + joystickSensitivity, 0f, 0f);
                        fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                    }
                //}
            }
        }


        // Take Off and Return
        if (takeOff)
        {
            Debug.LogWarning("Take off");
            fighterRoot.transform.position = new Vector3(fighterShip.transform.position.x - takeOffDistance, fighterShip.transform.position.y, fighterShip.transform.position.z);
        }

        if (dock)
        {
            Debug.LogWarning("Dock");
            fighterRoot.transform.position = new Vector3(fighterShip.transform.position.x + takeOffDistance, fighterShip.transform.position.y, fighterShip.transform.position.z);
        }
    }


    private IEnumerator TakeOff()
    {
        yield return new WaitForSeconds(3);
        takeOff = false;
        dock = false;
    }


    public void toggleIgnition()
    {
        if (ignition)
        {
            if (!takeOff || !dock)
            {
                dock = true;
                StartCoroutine("TakeOff");
            }
            jetEffect.SetActive(false);
            ignition = false;
        }

        else if (!ignition)
        {
            if (!takeOff || !dock)
            {
                takeOff = true;
                StartCoroutine("TakeOff");
            }
            jetEffect.SetActive(true);
            ignition = true;
        }
    }


    public void tiltUpOn()
    {
        tiltingUp = true;
    }
    public void tiltUpOff()
    {
        tiltingUp = false;
    }


    public void tiltDownOn()
    {
        tiltingDown = true;
    }
    public void tiltDownOff()
    {
        tiltingDown = false;
    }


    public void tiltLeftOn()
    {
        tiltingLeft = true;
    }
    public void tiltLeftOff()
    {
        tiltingLeft = false;
    }


    public void tiltRightOn()
    {
        tiltingRight = true;
    }
    public void tiltRightOff()
    {
        tiltingRight = false;
    }
}
