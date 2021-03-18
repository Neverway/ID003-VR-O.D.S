using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterManagerTriggerBased2 : MonoBehaviour
{
    //public float fighterHealth;
    //public float fighterFuel;
    //public int upgradedLasersID;

    public GameObject fighterShip; // Fighter game object
    public GameObject fighterRoot; // Root position of the fighter

    // Engine Stuff
    public GameObject displayOn;
    public GameObject jetEffect;    // The flame effect to enable on ignition

    public float takeOffDistance;   // How far forward should the ship fly on ignition?
    public float stepSpeed;         // forward take off speed
    public bool ignition;           // Is the engine on?
    private bool takeOff;           // Is the fighter trying to take off?
    private bool dock;              // Is the fighter trying to dock?

    // Joystick Controls
    public GameObject joystickPivot;
    private float pivotIdleX;   // Joystick idle/return position
    private float pivotIdleY;   // Joystick idle/return position
    private float pivotIdleZ;   // Joystick idle/return position

    private bool tiltingUp;     // Is the joystick in the up position?
    private bool tiltingDown;   // Is the joystick in the down position?
    private bool tiltingLeft;   // Is the joystick in the left position?
    private bool tiltingRight;  // Is the joystick in the right position?




    public float fighterTiltForwardLimit = -0.12f;
    public float fighterTiltBackwardLimit = 0.12f;
    public float fighterTiltLeftLimit = 0.1f;
    public float fighterTiltRightLimit = 0.1f;
    public float joystickSensitivity = 1f;
    public float joystickDeadzone = 0.5f;

    public void Start()
    {
        // Set the joystick idle/return position
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

            }
            // Return Horizontal
            if (!tiltingLeft && !tiltingRight)
            {

            }
        }


        // Take Off and Return
        if (takeOff)
        {
            Debug.LogWarning("Take off");
            // move the ship forward a set amount
            fighterShip.GetComponent<Rigidbody>().velocity = fighterRoot.transform.forward * takeOffDistance;
        }

        if (dock)
        {
            Debug.LogWarning("Dock");
            // move the ship backward a set amount
            fighterShip.GetComponent<Rigidbody>().velocity = -fighterRoot.transform.forward * takeOffDistance;
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
                jetEffect.SetActive(false);
                displayOn.SetActive(false);
                ignition = false;
            }
        }

        else if (!ignition)
        {
            if (!takeOff || !dock)
            {
                takeOff = true;
                StartCoroutine("TakeOff");
                jetEffect.SetActive(true);
                displayOn.SetActive(true);
                ignition = true;
            }
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
