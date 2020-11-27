using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFighterSpin : MonoBehaviour
{
    public float stepRateX = 1;
    public float stepRateY = 1;
    public float stepRateZ = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion localRotation = Quaternion.Euler(transform.rotation.x - stepRateX, 0f, 0f);
        transform.rotation = transform.rotation * localRotation;
    }
}
