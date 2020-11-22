using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InteractableFlashlight : MonoBehaviour
{
    public SteamVR_Action_Boolean activateAction;
    public GameObject spotlight;
    public GameObject pointlight;
    public AudioSource flashlightClick;
    public AudioSource flashlightClick2;
    public bool flashlightOn = false;
    private Throwable interactable;

    void Start()
    {
        interactable = GetComponent<Throwable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.interactable.attachedToHand.handType;

            if (activateAction[source].stateDown)
            {
                ToggleFlashlight();
                flashlightClick.Play();
            }

            if (activateAction[source].stateUp)
            {
                flashlightClick2.Play();
            }
        }

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
