using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideSkill : Skill
{
    public GameObject player;
    private sliderBar dashbar;
    public float maxSlideDuration = 3.0f;
    public float slideRechargeMultiplyer = 4f;
    private movement mv;
    private bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        mv = player.GetComponent<movement>();
        dashbar = skillUI.GetComponent<sliderBar>();
        dashbar.sliderMax(maxSlideDuration);
        cooldown = false;
    }

    public override void handleSkill(KeyCode k)
    {     
        if (mv.isCrouching && dashbar.getValue() > 0f && !cooldown)
        {
            dashbar.setSlider(Mathf.Max(dashbar.getValue() - Time.deltaTime, 0));
            mv.isSliding = true;
        }
        else
        {
            if (dashbar.getValue() <= 0)
            {
                cooldown = true;
            }

            if (dashbar.getValue() < maxSlideDuration)
            {
                dashbar.setSlider(Mathf.Min(dashbar.getValue() + Time.deltaTime / slideRechargeMultiplyer, maxSlideDuration));
            }
            mv.isSliding = false;

            if (cooldown && dashbar.getValue() >= maxSlideDuration)
            {
                cooldown = false;
            }
        }
    }
}
