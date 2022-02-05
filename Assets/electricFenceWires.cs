using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricFenceWires : MonoBehaviour
{
    [SerializeField] float damagePerTick;
    [SerializeField] float ticksPerSecond;

    private float timer;
    private bool doDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        doDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (doDamage)
        {
            timer = 0;
            doDamage = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Assets.Scripts.Enemies.IHealth ih = collision.transform.GetComponent<Assets.Scripts.Enemies.IHealth>();

        if (ih != null && timer >= 1/ticksPerSecond)
        {
            ih.TakeDamage(damagePerTick);
            doDamage = true;
        }
    }
}
