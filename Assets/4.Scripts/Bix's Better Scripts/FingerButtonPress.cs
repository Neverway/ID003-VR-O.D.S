using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class FingerButtonPress : MonoBehaviour
{
    public float Delay = 2f;
    private bool CanPress = true;
    public bool LoadTrigger;
    public GameObject trigger;
    public Transform Spawn;
    public UnityEvent VRPRess;
    private void Start()
    {
        if (LoadTrigger)
        {
            Instantiate(trigger, Spawn);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "BUTTON INTERACTOR(Clone)" && CanPress)
        {
            CanPress = false;
            VRPRess.Invoke();
            Invoke("enablePress", Delay);
        }
    }
    private void enablePress()
    {
        CanPress = true;
    }
}
