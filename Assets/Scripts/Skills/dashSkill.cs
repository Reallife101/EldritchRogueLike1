using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashSkill : Skill
{
    public GameObject player;
    private sliderBar dashbar;
    public float dashDelay = 5.0f;
    private ImpactReceiver ir;

    // Start is called before the first frame update
    void Start()
    {
        ir = player.GetComponent<ImpactReceiver>();
        dashbar = skillUI.GetComponent<sliderBar>();
        dashbar.sliderMax(dashDelay);
    }

    public override void handleSkill(KeyCode k)
    {
        if (dashbar.getValue() < dashDelay)
        {
            dashbar.setSlider(Mathf.Min(dashbar.getValue() + Time.deltaTime, dashDelay));
        }

        if (Input.GetKeyDown(k) && dashbar.getValue() >= dashDelay)
        {
            ir.AddImpact(player.transform.forward, 200f);
            dashbar.setSlider(0f);
        }
    }
}
