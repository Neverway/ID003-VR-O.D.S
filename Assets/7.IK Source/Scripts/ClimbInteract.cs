using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteract : XRBaseInteractable
{
    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);
        if (interactor is XRDirectInteractor)
        {
            IKClimb.climbingHand = interactor.GetComponent<XRController>();
        }
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        if (interactor is XRDirectInteractor)
        {
            if (IKClimb.climbingHand && IKClimb.climbingHand.name == interactor.name)
            {
                IKClimb.climbingHand = null;
            }
        }
    }
}
