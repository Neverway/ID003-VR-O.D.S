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

    public float takeOffDistance = 15;   // How far forward should the ship fly on ignition?
    public float stepSpeed;         // Ship speed
    public bool ignition;           // Is the engine on?
    public bool controlsPrimed;     // Are the controls active?
    private bool takeOff;           // Is the fighter trying to take off?
    private bool dock;              // Is the fighter trying to dock?

    // Joystick Controls
    public GameObject joystickPivot;
    private float pivotIdleX;   // Joystick idle/return position
    private float pivotIdleY;   // Joystick idle/return position
    private float pivotIdleZ;   // Joystick idle/return position

    public bool tiltingUp;     // Is the joystick in the up position?
    public bool tiltingDown;   // Is the joystick in the down position?
    public bool tiltingLeft;   // Is the joystick in the left position?
    public bool tiltingRight;  // Is the joystick in the right position?



    public Vector3 limits = new Vector3(6, 12, 0);
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
        if (ignition && controlsPrimed)
        {
            // Tilt Up
            if (tiltingUp)
            {
                Debug.Log(fighterShip.transform.localRotation.z);
                // Rotate until a certain position, then move ship
                if (fighterShip.transform.localRotation.z > fighterRoot.transform.localRotation.z - 0.12f)
                {
                    //Quaternion localRotation = Quaternion.Euler(0f, 0f, fighterShip.transform.rotation.z - .25f);
                    //fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                }
                if (fighterShip.transform.localPosition.y < 12)
                {
                    Vector3 movement = fighterRoot.transform.up * stepSpeed * Time.deltaTime;
                    fighterShip.transform.position = transform.position + movement;
                }
            }


            // Tilt Down
            if (tiltingDown)
            {
                if (fighterShip.transform.localRotation.z < fighterRoot.transform.localRotation.z + 0.12f)
                {
                    //Quaternion localRotation = Quaternion.Euler(0f, 0f, fighterShip.transform.rotation.z + .25f);
                    //fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                }
                if (fighterShip.transform.localPosition.y > -12)
                {
                    Vector3 movement = fighterRoot.transform.up * stepSpeed * Time.deltaTime;
                    fighterShip.transform.position = transform.position - movement;
                }
            }


            // Tilt Right
            if (tiltingRight)
            {
                // Rotate until a certain position, then move ship
                if (fighterShip.transform.localRotation.x < fighterRoot.transform.localRotation.x + 0.2f)
                {
                    //Quaternion localRotation = Quaternion.Euler(fighterShip.transform.rotation.x + .5f, 0f, 0f);
                    //fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                }
                if (fighterShip.transform.localPosition.x < 12)
                {
                    Vector3 movement = fighterRoot.transform.right * stepSpeed * Time.deltaTime;
                    fighterShip.transform.position = transform.position + movement;
                }
            }


            // Tilt Left
            if (tiltingLeft)
            {
                // Rotate until a certain position, then move ship
                if (fighterShip.transform.localRotation.x > fighterRoot.transform.localRotation.x - 0.2f)
                {
                    //Quaternion localRotation = Quaternion.Euler(fighterShip.transform.rotation.x - .5f, 0f, 0f);
                    //fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                }
                if (fighterShip.transform.localPosition.x > -12)
                {
                    Vector3 movement = fighterRoot.transform.right * stepSpeed * Time.deltaTime;
                    fighterShip.transform.position = transform.position - movement;
                }
            }

            // Returning tilt
            ReturnShipRotations2();
        }


        // Take Off and Return
        if (takeOff)
        {
            Debug.LogWarning("Take off");
            // move the ship forward a set amount
            Vector3 movement = fighterRoot.transform.forward * takeOffDistance * Time.deltaTime;
            fighterShip.GetComponent<Rigidbody>().MovePosition(transform.position + movement);
        }

        if (dock)
        {
            Debug.LogWarning("Dock");
            // move the ship backward a set amount
            Vector3 movement = fighterRoot.transform.forward * takeOffDistance * Time.deltaTime;
            fighterShip.GetComponent<Rigidbody>().MovePosition(transform.position - movement);
        }
    }


    private IEnumerator TakeOff()
    {
        yield return new WaitForSeconds(3);
        takeOff = false;
        dock = false;
        yield return new WaitForSeconds(1);
        controlsPrimed = true;
    }

    private IEnumerator Dock()
    {
        yield return new WaitForSeconds(3);
        controlsPrimed = false;
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
                StartCoroutine("Dock");
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

    private void ReturnShipRotations2()
    {
        
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
