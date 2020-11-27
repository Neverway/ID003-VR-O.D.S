using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableSkeeball : MonoBehaviour
{
    public TextMeshPro textTarget;
    public int score;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textTarget.text = "SCORE: " + score.ToString();
    }

    public void addScore(int inputScore)
    {
        score += inputScore;
    }
}
