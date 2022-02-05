using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcePushSkill : Skill
{
    [SerializeField] float radius;
    [SerializeField] LayerMask PlayerLayerMask;
    [SerializeField] float pushBackForce;
    [SerializeField] float damage;

    public GameObject player;
    public float maxDuration = 5.0f;
    public float rechargeMultiplier = 3f;

    private sliderBar dashbar;
    private bool cooldown;


    // Start is called before the first frame update
    void Start()
    {
        dashbar = skillUI.GetComponent<sliderBar>();
        dashbar.sliderMax(maxDuration);
        cooldown = false;
    }

    public override void handleSkill(KeyCode k)
    {
        if (Input.GetKeyDown(k) && !cooldown)
        {
            pushBack();
            dashbar.setSlider(0f);
            cooldown = true;
        }
        else
        {

            if (dashbar.getValue() < maxDuration)
            {
                dashbar.setSlider(Mathf.Min(dashbar.getValue() + Time.deltaTime / rechargeMultiplier, maxDuration));
            }

            if (cooldown && dashbar.getValue() >= maxDuration)
            {
                cooldown = false;
            }
        }
    }

    public void pushBack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, radius, ~PlayerLayerMask);
        foreach (var hitCollider in hitColliders)
        {
            //do damage
            Assets.Scripts.Enemies.IHealth ih = hitCollider.transform.GetComponent<Assets.Scripts.Enemies.IHealth>();

            bool v = ih is MultiplierHealth;
            if (ih != null && !v)
            {
                ih.TakeDamage(damage);
            }

            //apply push back force
            Rigidbody rb = hitCollider.transform.GetComponent<Rigidbody>();

            if (rb)
            {
                rb.AddForce((hitCollider.transform.position - player.transform.position).normalized * pushBackForce, ForceMode.VelocityChange);
            }
        }
    }
}
