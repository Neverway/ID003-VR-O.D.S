using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnConditions : MonoBehaviour
{
    public float respawnHeight;
    public Transform respawnLocationTarget;
    public GameObject playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (playerTarget.transform.position.y <= respawnHeight)
        {
            playerTarget.transform.position = respawnLocationTarget.position;
        }
    }
}
