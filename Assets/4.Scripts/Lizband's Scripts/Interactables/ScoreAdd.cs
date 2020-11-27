using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    public InteractableSkeeball interactableSkeeball;
    public int InputScore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Skeeball")
        {
            interactableSkeeball.addScore(InputScore);
        }
    }
}
