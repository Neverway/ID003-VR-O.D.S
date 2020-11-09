using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDoor : MonoBehaviour
{
    public GameObject leftHalf;
    public GameObject rightHalf;
    public Transform leftClosedTarget;
    public Transform rightClosedTarget;
    public Transform leftOpenTarget;
    public Transform rightOpenTarget;

    public float speed = 0.02f;
    public bool automaticlyOpen;
    public bool doorsOpen = false;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (!doorsOpen)
        {
            leftHalf.transform.position = Vector3.MoveTowards(leftHalf.transform.position, leftClosedTarget.position, Time.deltaTime * speed);
            rightHalf.transform.position = Vector3.MoveTowards(rightHalf.transform.position, rightClosedTarget.position, Time.deltaTime * speed);
        }

        if (doorsOpen)
        {
            leftHalf.transform.position = Vector3.MoveTowards(leftHalf.transform.position, leftOpenTarget.position, Time.deltaTime * speed);
            rightHalf.transform.position = Vector3.MoveTowards(rightHalf.transform.position, rightOpenTarget.position, Time.deltaTime * speed);
        }
    }


    public void ToggleDoor()
    {
        if (doorsOpen)
        {
            //CloseDoor();
            doorsOpen = false;
        }
        else if (!doorsOpen)
        {
            //OpenDoor();
            doorsOpen = true;
        }
    }
}
