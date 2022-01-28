using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    public Rigidbody rb;
    public int hitCount;
    public int maxHit = 5;
    public float popPower = 10;
    public float rotatePower = 10;
    public bool fallen = false;
    private Vector3 resetPos;
    private Quaternion resetRot;

    private void Start()
    {
        resetPos = transform.position;
        resetRot = transform.rotation;
    }
    private void Update()
    {
        if (hitCount == maxHit && fallen == false)
        {
            Invoke("dropCover", 2f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Hit"))
        {
            hitCount += 1;
        }
        
        /*if (collision.transform.CompareTag("Hit") && hitCount==5)
        {
            Invoke("dropCover", 2f);
        }*/
    }
    void dropCover()
    {
        rb.constraints = RigidbodyConstraints.None;
        //rb.AddForce(Vector3.up * popPower/2);
        rb.AddForce(Vector3.right * -popPower);
        rb.AddTorque(Vector3.right * -rotatePower);
        fallen = true;
    }
    public void setPos()
    {
        
        hitCount = 0;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        transform.position = resetPos;
        transform.rotation = resetRot;
        fallen = false;
    }
}
