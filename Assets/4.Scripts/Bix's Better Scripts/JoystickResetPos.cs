using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickResetPos : MonoBehaviour
{
    //public GameObject positionTarget;
    public GameObject joystickTarget;
    //public GameObject joystickRootTarget;
    public bool attached;
    public Vector3 bob = new Vector3(-0.2f,0,0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!attached && transform.position != bob)
        {
            /*
            && joystickTarget.transform.position != positionTarget.transform.position
            joystickTarget.transform.position = positionTarget.transform.position;
            joystickRootTarget.transform.position = positionTarget.transform.position;
            joystickRootTarget.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            */

            transform.position = joystickTarget.transform.position;
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
