using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprintSkill : Skill
{
    public GameObject player;
    private sliderBar dashbar;
    public float maxSprintDuration = 5.0f;
    public float sprintRechargeMultiplyer = 3f;
    private movement mv;
    private bool cooldown;


    // Start is called before the first frame update
    void Start()
    {
        mv = player.GetComponent<movement>();
        dashbar = skillUI.GetComponent<sliderBar>();
        dashbar.sliderMax(maxSprintDuration);
        cooldown = false;
    }

    public override void handleSkill(KeyCode k)
    {
        if (Input.GetKey(KeyCode.LeftShift) && dashbar.getValue() > 0f && !cooldown && !mv.isSliding)
        {
            dashbar.setSlider(Mathf.Max(dashbar.getValue() - Time.deltaTime, 0));
            mv.isSprinting = true;
        }
        else
        {
            if (dashbar.getValue() <=0)
            {
                cooldown = true;
            }
            
            if (dashbar.getValue() < maxSprintDuration)
            {
                dashbar.setSlider(Mathf.Min(dashbar.getValue() + Time.deltaTime/sprintRechargeMultiplyer, maxSprintDuration));
            }
            mv.isSprinting = false;

            if (cooldown && dashbar.getValue() >= maxSprintDuration)
            {
                cooldown = false;
            }
        }
    }
}
