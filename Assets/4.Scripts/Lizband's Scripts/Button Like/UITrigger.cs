using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UITrigger : MonoBehaviour
{
    public UnityEvent onUITriggerEnter;
    public UnityEvent onUITriggerExit;

    private void OnTriggerEnter()
    {
        onUITriggerEnter.Invoke();
    }


	private void OnTriggerExit()
	{
        onUITriggerExit.Invoke();
	}
}
