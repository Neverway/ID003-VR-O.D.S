using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFlashlight : MonoBehaviour
{
    public GameObject spotlight;
    public GameObject pointlight;
    public bool flashlightOn=false;

    // Update is called once per frame
    void Update()
    {
        if (flashlightOn)
        {
            spotlight.SetActive(true);
            pointlight.SetActive(true);
        }

        if (!flashlightOn)
        {
            spotlight.SetActive(false);
            pointlight.SetActive(false);
        }
    }

    public void ToggleFlashlight()
    {
        if (flashlightOn)
        {
            flashlightOn = false;
        }
        else if (!flashlightOn)
        {
            flashlightOn = true;
        }
    }
}
