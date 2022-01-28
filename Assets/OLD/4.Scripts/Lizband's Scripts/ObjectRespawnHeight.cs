using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawnHeight : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject respawnTarget;
    public float respawnHeight = -100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject.transform.position.y <= respawnHeight)
        {
            targetObject.transform.position = respawnTarget.transform.position;
            targetObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
