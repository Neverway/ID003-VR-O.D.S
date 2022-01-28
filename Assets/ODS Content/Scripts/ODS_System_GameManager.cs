using UnityEngine;
using UnityEngine.UI;

public class ODS_System_GameManager : MonoBehaviour
{
    public ODS_UI_Timer timer;
    public ODS_MotherShip_Throttle throttle;
    public int gameState = 0; // 0 - not started, 1 - playing, 2 - gameover (won), 3 - gameover (lost)
    public GameObject missionFailScreen;
    public GameObject missionCompleteScreen;
    private Transform mapStartLocation;

    void Start()
    {
        mapStartLocation = throttle.motherShipRoot.transform;
    }

    public void GameStart()
    {
        missionFailScreen.transform.GetChild(0).GetComponent<Text>().text = "[{ERROR: UNKNOWN FAILURE}]";
        missionFailScreen.SetActive(false);
        gameState = 1;
        throttle.motherShipRoot.transform.position = mapStartLocation.position;
        throttle.motherShipRoot.transform.rotation = mapStartLocation.rotation;
        timer.StartTimer();
        throttle.acceptingInput = true;
    }

    public void GameWin()
    {
        if (gameState == 1)
        {
            missionCompleteScreen.SetActive(true);
            gameState = 2;
            timer.StopTimer("Won");
            timer.timerText.color = timer.timerWinStop;
            throttle.StopAllEngines();
        }
    }

    public void GameOver(string reason)
    {
        if (gameState == 1)
        {
            missionFailScreen.SetActive(true);
            missionFailScreen.transform.GetChild(0).GetComponent<Text>().text = $"[{reason}]";
            gameState = 3;
            timer.StopTimer("Lost");
            timer.timerText.color = timer.timerLoseStop;
            throttle.StopAllEngines();
        }
    }
}
