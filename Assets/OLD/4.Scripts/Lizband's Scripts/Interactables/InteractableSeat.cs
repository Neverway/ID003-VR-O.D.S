using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSeat : MonoBehaviour
{
    public GameObject playerTarget;
    public GameObject playerHandsParent;
    public GameObject[] playerHands;
    public Transform seatedTransform;
    public Transform exitTransform;
    public bool seated;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (seated)
        {
            playerTarget.transform.position = seatedTransform.position; // Lock the player into the seat
        }
    }

    public void toggleSeated()
    {
        if (seated)
        {
            seated = false;
            // Re-child the hands from to player
            GameObject.Find("HandColliderLeftWrist(Clone)").transform.parent = playerTarget.transform;
            GameObject.Find("HandColliderRightWrist(Clone)").transform.parent = playerTarget.transform;
            foreach (var hand in playerHands)
            {
                hand.transform.parent = playerHandsParent.transform;
            }
            playerTarget.transform.parent = null;  // Un-parent the player from the seat
            playerTarget.transform.position = exitTransform.position; // Set the players position as they exit the seat
        }
        else if (!seated)
        {
            seated = true;
            // Temporarily de-child the hands from the player to avoid jitter
            GameObject.Find("HandColliderLeftWrist(Clone)").transform.parent = null;
            GameObject.Find("HandColliderRightWrist(Clone)").transform.parent = null;
            foreach (var hand in playerHands)
            {
                hand.transform.parent = null;
            }
            playerTarget.transform.parent = seatedTransform;  // Parent the player to the seat
        }
    }
}
