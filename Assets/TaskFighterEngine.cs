using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFighterEngine : MonoBehaviour
{
    public bool taskActive;
    public bool hasStatusIndicator;
    public GameObject pilotLight;
    public GameObject statusIndicator;
    public Material indicatorBad;
    public Material indicatorGood;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Flame"))
        {
            DeactivateTask();
        }
    }


    public void ActivateTask()
    {
        taskActive = true;
        pilotLight.SetActive(false);
        if (hasStatusIndicator)
        {
            statusIndicator.GetComponent<MeshRenderer>().material = indicatorBad;
        }
    }


    public void DeactivateTask()
    {
        taskActive = false;
        pilotLight.SetActive(true);
        if (hasStatusIndicator)
        {
            statusIndicator.GetComponent<MeshRenderer>().material = indicatorGood;
        }
    }
}
