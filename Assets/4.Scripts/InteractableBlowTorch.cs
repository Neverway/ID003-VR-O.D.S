using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBlowTorch : MonoBehaviour
{
    public GameObject flame;
    public GameObject flameTrigger;
    public bool blowTorchOn=false;

    // Update is called once per frame
    void Update()
    {
        if (blowTorchOn)
        {
            flame.SetActive(true);
            flameTrigger.SetActive(true);
        }

        if (!blowTorchOn)
        {
            flame.SetActive(false);
            flameTrigger.SetActive(false);
        }
    }

    public void ToggleTorch()
    {
        if (blowTorchOn)
        {
            blowTorchOn = false;
        }
        else if (!blowTorchOn)
        {
            blowTorchOn = true;
        }
    }
}
