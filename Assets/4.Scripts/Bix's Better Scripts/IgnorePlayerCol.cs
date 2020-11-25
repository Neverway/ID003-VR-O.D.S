using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCol : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("PlayerCollider"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
