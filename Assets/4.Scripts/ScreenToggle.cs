using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenToggle : MonoBehaviour
{
    public GameObject PlayerHead;
    public GameObject ScreenUI;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            ScreenUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            ScreenUI.SetActive(false);
        }
    }
}
