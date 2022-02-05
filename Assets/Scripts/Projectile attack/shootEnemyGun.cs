using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootEnemyGun : MonoBehaviour
{
    [SerializeField] AudioSource au;

    public GameObject projectile;
    public GameObject gun;
    private GameObject player;

    public float attackRange = 30f;

    public float shotCooldown = 0.5f;
    public float burstCooldown = 3f;
    public int numShots = 3;

    private float shotTimer = 0f;
    private float burstTimer = 0f;

    private int shotCounter = 0;

    [SerializeField]
    int playerLayer = 8;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }



    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
        {
            transform.LookAt(player.transform);

            RaycastHit hit;

            if (burstTimer > burstCooldown && Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, attackRange))
            {
                
                if (shotTimer > shotCooldown && hit.collider.gameObject.layer == playerLayer)
                {
                    Instantiate(projectile, gun.transform.position + gun.transform.forward + new Vector3(0, -0.1f, 0), gun.transform.rotation);
                    au.Play();
                    shotTimer = 0f;
                    shotCounter += 1;

                    if (shotCounter >= numShots)
                    {
                        shotCounter = 0;
                        burstTimer = 0f;
                    }
                }
            }
            shotTimer += Time.deltaTime;
            burstTimer += Time.deltaTime;
        }
    }
}
