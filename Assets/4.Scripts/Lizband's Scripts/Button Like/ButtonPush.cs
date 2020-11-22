﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public GameObject buttonObject;
    public Material defaultMaterial;
    public Material pushedMaterial;

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
