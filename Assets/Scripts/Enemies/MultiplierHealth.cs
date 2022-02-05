using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierHealth : Assets.Scripts.Enemies.IHealth
{
    [SerializeField] Assets.Scripts.Enemies.IHealth mainHealth;

    [SerializeField] float damageMultiplier;

    public override float GetHealth()
    {
        return mainHealth.GetHealth();
    }

    public override void HealDamage(float healing)
    {
        mainHealth.HealDamage(healing);
    }

    public override void TakeDamage(float damage)
    {
        mainHealth.TakeDamage(damage * damageMultiplier);
    }

}
