using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneRespawn : MonoBehaviour
{
    public Transform respawnTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(respawnTarget.position.x, respawnTarget.position.y, respawnTarget.position.z);
    }
}
