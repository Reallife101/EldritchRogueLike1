using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcePullSkill : Skill
{
    [SerializeField] Camera cam;
    [SerializeField] float range;
    [SerializeField] LayerMask PlayerLayerMask;
    [SerializeField] float pullForce;

    public GameObject player;
    public float maxDuration = 5.0f;
    public float rechargeMultiplier = 3f;

    private sliderBar dashbar;
    private bool cooldown;
    private ImpactReceiver ir;
    private movement mov;


    // Start is called before the first frame update
    void Start()
    {
        ir = player.GetComponent<ImpactReceiver>();
        mov = player.GetComponent<movement>();
        dashbar = skillUI.GetComponent<sliderBar>();
        dashbar.sliderMax(maxDuration);
        cooldown = false;
    }

    public override void handleSkill(KeyCode k)
    {
        if (Input.GetKeyDown(k) && !cooldown)
        {
            pull();
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

    public void pull()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, ~PlayerLayerMask))
        {
            dashbar.setSlider(0f);
            cooldown = true;

            //apply pull force
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();

            Vector3 flightPath = (hit.point - player.transform.position).normalized;
            if (flightPath.y<0)
            {
                flightPath.y = 0;
            }

            if (rb)
            {
                rb.AddForce((hit.transform.position - player.transform.position).normalized * -pullForce, ForceMode.VelocityChange);
                StartCoroutine(pf(flightPath, 1.5f));
            }
            else
            {
                StartCoroutine(pf(flightPath, 3f));
            }

        }
    }

    IEnumerator pf(Vector3 dir, float amount)
    {
        for (float i = amount; i >= 0f; i -= .5f)
        {
            ir.AddImpact(dir, pullForce * i);
            yield return new WaitForSeconds(.1f);
        }
    }    
}
