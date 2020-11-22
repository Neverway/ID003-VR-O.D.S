using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickResetPos : MonoBehaviour
{
    public GameObject positionTarget;
    public GameObject joystickTarget;
    public GameObject joystickRootTarget;
    public bool attached;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!attached && joystickTarget.transform.position != positionTarget.transform.position)
        {
            joystickTarget.transform.position = positionTarget.transform.position;
            joystickRootTarget.transform.position = positionTarget.transform.position;
            joystickTarget.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            joystickRootTarget.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    public void attach()
    {
        attached = true;
    }

    public void unattach()
    {
        attached = false;
    }
}
