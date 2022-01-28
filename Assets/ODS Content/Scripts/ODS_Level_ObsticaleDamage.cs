using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ODS_Level_ObsticaleDamage : MonoBehaviour
{
    public float Damage = 5f;
    public ODS_MotherShip_Health motherShip;
    public GameObject explosionEffect;
    public bool destructable;

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
        if (other.gameObject.tag == "ODS_Ship")
        {
            motherShip.MotherShipTakeDamage(Damage);
            if (destructable)
            {
                Instantiate(explosionEffect, gameObject.transform.position, Quaternion.identity);
                GameObject.Destroy(gameObject);
                destructable = false;
            }
        }
    }
}
