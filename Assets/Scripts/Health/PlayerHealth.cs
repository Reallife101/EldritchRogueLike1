using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Assets.Scripts.Enemies.IHealth
{
    public sliderBar sb;
    public float health = 100;

    private float maxHealth;

    private void Start()
    {
        sb.sliderMax(health);
        maxHealth = health;
    }

    public override float GetHealth()
    {
        return health;
    }

    public override void HealDamage(float healing)
    {
        health = Mathf.Min(health + healing, maxHealth);
        sb.setSlider(health);
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;

        sb.setSlider(health);

        if (health < 0.0000001)
        {
            die();
        }
    }

    private void die()
    {
        Debug.Log("Player Death");
    }

}
