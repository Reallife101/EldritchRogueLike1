using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doDamage : MonoBehaviour
{
    public int damageValue = 5;
    public int destroyMask;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == destroyMask)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.GetComponent<Assets.Scripts.Enemies.IHealth>())
        {
            collision.gameObject.GetComponent<Assets.Scripts.Enemies.IHealth>().TakeDamage(damageValue);
            Destroy(gameObject);
        }
    }
}