using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableTriggerEvents : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "JOY")
        {
            onTriggerEnter.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "JOY")
        {
            onTriggerExit.Invoke();
        }
    }
}
