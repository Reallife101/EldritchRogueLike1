using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour
{
    [SerializeField] float meleeCooldown;
    [SerializeField] Camera cam;
    [SerializeField] float range;
    [SerializeField] LayerMask PlayerLayerMask;
    [SerializeField] float damage;
    [SerializeField] float pushBackForce;
    public GameObject player;

    public KeyCode key = KeyCode.V;

    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key) && timer >= meleeCooldown)
        {
            timer = 0;
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, ~PlayerLayerMask))
            {
                //do damage
                Assets.Scripts.Enemies.IHealth ih = hit.transform.GetComponent<Assets.Scripts.Enemies.IHealth>();

                if (ih != null)
                {
                    ih.TakeDamage(damage);
                }

                //apply Knockback
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();

                if (rb)
                {
                    rb.AddForce((hit.transform.position - player.transform.position).normalized * pushBackForce, ForceMode.VelocityChange);
                }
            }

        }

        timer = Mathf.Min(timer + Time.deltaTime, meleeCooldown);
    }
}
