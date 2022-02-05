using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enemies;

public class HitscanGun : Assets.Scripts.Guns.AGun
{
    [SerializeField] private uint bulletsPerShot;
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    [SerializeField] private Camera mainCamera;
    private float nextTimeToFire;
    [SerializeField] private float range;
    [SerializeField] private float spread;
    [SerializeField] private GameObject hitEffect;

    public HitscanGun(Camera mainCamera, uint bulletsPerShot, float damage,
        float fireRate, float range, float spread)
    {
        this.bulletsPerShot = bulletsPerShot;
        this.damage = damage;
        this.fireRate = fireRate;
        this.mainCamera = mainCamera;
        nextTimeToFire = Time.time;
        this.range = range;
        this.spread = spread;
    }

    public void OnDrawGizmosSelected()
    {
        /* Draw spread reticle */
        Gizmos.color = Color.red;
        Vector3 position = mainCamera.transform.position, 
            forward = mainCamera.transform.forward,
            up = mainCamera.transform.up, 
            right = mainCamera.transform.right,
            direction = (forward + right * spread) * range;
        Gizmos.DrawRay(position, direction);
        direction = (forward + right * -spread) * range;
        Gizmos.DrawRay(position, direction);
        direction = (forward + up * spread) * range;
        Gizmos.DrawRay(position, direction);
        direction = (forward + up * -spread) * range;
        Gizmos.DrawRay(position, direction);
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(position + forward * range,
            -forward, spread * range, 0.3f);
    }

    public override void Shoot()
    {
        if (nextTimeToFire < Time.time)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            Vector3 position = mainCamera.transform.position,
                forward = mainCamera.transform.forward,
                up = mainCamera.transform.up,
                right = mainCamera.transform.right,
                direction;
            for (int i = 0; i < bulletsPerShot; i++)
            {
                RaycastHit hit;
                //direction = forward + up * Random.Range(-spread, spread) + right * Random.Range(-spread, spread);
                direction = forward + (Vector3)Random.insideUnitCircle * spread;
                if (Physics.Raycast(position, direction, out hit, range))
                {
                    stringBuilder.Append(hit.transform.name + " ");
                    IHealth healthObj = hit.transform.gameObject.GetComponent<IHealth>();
                    healthObj.TakeDamage(damage);
                    GameObject effect = Instantiate(hitEffect, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(-hit.normal));
                    Destroy(effect, 1.0f);
                }
            }
            Debug.Log(stringBuilder.ToString());
            nextTimeToFire = Time.time + fireRate;
        }
    }

    public override void Reload() { }
}
