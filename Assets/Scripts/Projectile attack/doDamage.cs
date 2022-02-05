using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doDamage : MonoBehaviour
{
    public int damageValue = 5;
    public int destroyMask;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == destroyMask)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageValue);
            Destroy(gameObject);
        }
    }

}