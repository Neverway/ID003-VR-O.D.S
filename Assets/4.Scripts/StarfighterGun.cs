using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfighterGun : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform leftBarrel;
    public Transform rightBarrel;
    //public AudioSource audioSource;
    //public AudioClip audioClip;

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, leftBarrel.position, leftBarrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * leftBarrel.forward;
        Destroy(spawnedBullet, 2);

        GameObject spawnedBullet2 = Instantiate(bullet, rightBarrel.position, rightBarrel.rotation);
        spawnedBullet2.GetComponent<Rigidbody>().velocity = speed * rightBarrel.forward;
        Destroy(spawnedBullet2, 2);
    }
}
