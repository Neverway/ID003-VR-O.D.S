using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePen : MonoBehaviour
{
    public GameObject penParticle;
    public Transform point;
    private bool drawing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (drawing)
        {
            Instantiate(penParticle, point.position, Quaternion.identity);
        }
    }

    public void startDraw()
    {
        drawing = true;
    }

    public void stopDraw()
    {
        drawing = false;
    }
}
