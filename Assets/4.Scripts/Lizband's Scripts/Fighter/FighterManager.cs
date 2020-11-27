using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterManager : MonoBehaviour
{
    public GameObject fighterShip;
    public float fighterHealth;
    public float fighterFuel;
    public int upgradedLasersID;

    // Engine Stuff
    public float takeOffDistance;
    public bool ignition;
    public bool takeOff;
    public bool dock;
    public GameObject jetEffect;

    // Joystick Controls
    public GameObject joystickPivot;
    public float pivotIdleX;
    public float pivotIdleY;
    public float pivotIdleZ;

    public float fighterTiltForwardLimit = 0.1f;
    public float fighterTiltBackwardLimit = -0.06f;
    public float fighterTiltLeftLimit = 0.1f;
    public float fighterTiltRightLimit = 0.1f;
    public float joystickSensitivity = 1f;
    public float joystickDeadzone = 0.5f;

    public void Start()
    {
        pivotIdleX = joystickPivot.transform.rotation.x;
        pivotIdleY = joystickPivot.transform.rotation.y;
        pivotIdleZ = joystickPivot.transform.rotation.z;

        fighterTiltForwardLimit = 0.1f;
    }


    private void Update()
    {
        if (ignition)
        {
            // Joystick Tilt Forward
            if (joystickPivot.transform.rotation.z > pivotIdleZ + joystickDeadzone)
            {
                //if (fighterShip.transform.rotation.z <= fighterTiltForwardLimit)
                //{
                Quaternion localRotation = Quaternion.Euler(0f, 0f, fighterShip.transform.rotation.z - joystickSensitivity);
                fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                Debug.Log("FTilt");
                //}
            }
            // Joystick Tilt Backward
            if (joystickPivot.transform.rotation.z < pivotIdleZ - joystickDeadzone)
            {
                Quaternion localRotation = Quaternion.Euler(0f, 0f, fighterShip.transform.rotation.z + joystickSensitivity);
                fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
                Debug.Log("BTilt");
            }
            // Joystick Tilt Right
            //if (joystickPivot.transform.rotation.x > pivotIdleX + joystickDeadzone)
            //{
            //    Quaternion localRotation = Quaternion.Euler(fighterShip.transform.rotation.x + joystickSensitivity, 0f, 0f);
            //    fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
            //    Debug.Log("RTilt");
            //}
            // Joystick Tilt Left
            //if (joystickPivot.transform.rotation.x < pivotIdleX - joystickDeadzone)
            //{
            //    Quaternion localRotation = Quaternion.Euler(fighterShip.transform.rotation.x - joystickSensitivity, 0f, 0f);
            //    fighterShip.transform.rotation = fighterShip.transform.rotation * localRotation;
            //    Debug.Log("LTilt");
            //}

        }

        if (takeOff)
        {
            Debug.LogWarning("Take off");
            fighterShip.transform.position = new Vector3(fighterShip.transform.position.x - takeOffDistance, fighterShip.transform.position.y, fighterShip.transform.position.z);
        }

        if (dock)
        {

            Debug.LogWarning("Dock");
            fighterShip.transform.position = new Vector3(fighterShip.transform.position.x + takeOffDistance, fighterShip.transform.position.y, fighterShip.transform.position.z);
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
            Debug.LogWarning("Ignition disabled");
            StopAllCoroutines();
            dock = true;
            StartCoroutine("TakeOff");
            jetEffect.SetActive(false);
            ignition = false;
        }

        else if (!ignition)
        {
            Debug.LogWarning("Ignition enabled");
            StopAllCoroutines();
            takeOff = true;
            StartCoroutine("TakeOff");
            jetEffect.SetActive(true);
            ignition = true;
        }
    }
}
