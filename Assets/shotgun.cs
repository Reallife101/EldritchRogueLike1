using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    [SerializeField] GameObject impactEffect;
    [SerializeField] LayerMask playerMask;
    //[SerializeField] ParticleSystem muzzleFlash;

    public float damage = 5f;
    public float range = 100f;
    public float fireRate = 2f;
    public float impactForce = 30f;
    public int maxAmmo = 1;
    public float reloadTime = 1f;

    private Camera fpsCam;
    //private audioHandler ah;
    private float nextTimeToFire = 0f;


    void Start()
    {
        fpsCam = Camera.main;
        //ah = GameObject.FindGameObjectWithTag("AudioHandler").GetComponent<audioHandler>();
    }

    private void OnEnable()
    {
       // ah = GameObject.FindGameObjectWithTag("AudioHandler").GetComponent<audioHandler>();
        //ah.playShotgunEquip();
    }

    private void OnDisable()
    {
        //ah.playPistolEquip();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        //muzzleFlash.Play();
        //ah.playShotgun1();
        //CameraShaker.Instance.ShakeOnce(4f, 10f, 0.1f, .5f);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~playerMask))
        {
            onhit(hit);
        }
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + new Vector3(0.1f, 0, 0), out hit, range, ~playerMask))
        {
            onhit(hit);
        }
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + new Vector3(-0.1f, 0, 0), out hit, range, ~playerMask))
        {
            onhit(hit);
        }
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + new Vector3(0.05f, 0, 0), out hit, range, ~playerMask))
        {
            onhit(hit);
        }
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward + new Vector3(-0.05f, 0, 0), out hit, range, ~playerMask))
        {
            onhit(hit);
        }
    }

    void onhit(RaycastHit hit)
    {
        Assets.Scripts.Enemies.IHealth health = hit.transform.GetComponent<Assets.Scripts.Enemies.IHealth>();
        //Debug.Log(hit.transform.name);
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(hit.normal * impactForce);
        }

        Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
    }
}
