using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPush : MonoBehaviour
{
    public GameObject buttonObject;
    public Material defaultMaterial;
    public Material pushedMaterial;
    public UnityEvent onTriggerEnter;

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
        if (other.gameObject == buttonObject)
        {
            onTriggerEnter.Invoke();
            buttonObject.GetComponent<MeshRenderer>().material = pushedMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == buttonObject)
        {
            buttonObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }
}
