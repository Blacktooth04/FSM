using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankAI : MonoBehaviour {

    public GameObject player;
    public GameObject bullet;
    public GameObject turret; // help align bullet with tank turret
    Animator anim;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] float firingTime = 0.5f;
    [SerializeField] float firingRepeatRate = 0.5f;
    [SerializeField] int bulletForce = 500;

    public GameObject GetPlayer()
    {
        return player;
    }

    void Fire()
    {
        // create a cartridge starting at the turret, firing at the rotation of the turret
        GameObject cartridge = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        cartridge.GetComponent<Rigidbody>().AddForce(turret.transform.forward * bulletForce);
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", firingTime, firingRepeatRate);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetFloat("Distance", Vector3.Distance(transform.position, player.transform.position));
	}


}
