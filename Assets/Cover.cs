using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    public Rigidbody rb;
    public int hitCount;
    public float popPower = 10;
    private Vector3 resetPos;
    private Quaternion resetRot;

    private void Start()
    {
        resetPos = transform.position;
        resetRot = transform.rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Hit"))
        {
            hitCount += 1;
        }
        
        if (collision.transform.CompareTag("Hit") && hitCount==5)
        {
            Invoke("dropCover", 2f);
        }
    }
    void dropCover()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(Vector3.up * popPower/2);
        rb.AddForce(Vector3.forward * -popPower);
    }
    public void setPos()
    {
        
        hitCount = 0;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        transform.position = resetPos;
        transform.rotation = resetRot;
    }
}
