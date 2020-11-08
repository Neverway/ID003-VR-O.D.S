using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfighterIgnition : MonoBehaviour
{
    public GameObject jetEffect;
    public bool ignitionOn = false;

    // Update is called once per frame
    void Update()
    {
        if (ignitionOn)
        {
            jetEffect.SetActive(true);
        }

        if (!ignitionOn)
        {
            jetEffect.SetActive(false);
        }
    }

    public void ToggleIgnition()
    {
        if (ignitionOn)
        {
            ignitionOn = false;
        }
        else if (!ignitionOn)
        {
            ignitionOn = true;
        }
    }
}
