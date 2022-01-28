using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ODS_UI_Timer : MonoBehaviour
{
    public Text timerText;
    public Color timerCounting;
    public Color timerWinStop;
    public Color timerLoseStop;
    private float startTime;
    private bool counting = false;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            timerText.color = timerCounting;
            t = Time.time - startTime;
            string hours = ((int)t / 60 / 60).ToString();
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = $"{hours}:{minutes}:{seconds}";
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        counting = true;
    }

    public void StopTimer(string gameState)
    {
        counting = false;
    }
}
