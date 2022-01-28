using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ODS_Trigger_UnityEvents : MonoBehaviour
{
    public string triggerTargetTag;
    public string triggerTargetName;
    public UnityEvent _onTriggerEnter;
    public UnityEvent _onTriggerExit;
    public UnityEvent _onTriggerStay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        print("Collided");

        if (other.gameObject.tag == triggerTargetTag)
        {
            _onTriggerEnter.Invoke();
            print("Triggered");
        }
            
    }
}
