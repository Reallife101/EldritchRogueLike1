using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeSlowSkill : Skill
{
    [SerializeField] float slowdownFactor;
    
    public float maxDuration = 5.0f;
    public float rechargeMultiplyer = 3f;
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
        if (Input.GetKey(k) && dashbar.getValue() > 0f && !cooldown)
        {
            dashbar.setSlider(Mathf.Max(dashbar.getValue() - Time.deltaTime, 0));
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        else
        {
            if (dashbar.getValue() <= 0)
            {
                cooldown = true;
            }

            if (dashbar.getValue() < maxDuration)
            {
                dashbar.setSlider(Mathf.Min(dashbar.getValue() + Time.deltaTime / rechargeMultiplyer, maxDuration));
            }

            //Turn off time slow
            Time.timeScale = 1f;

            if (cooldown && dashbar.getValue() >= maxDuration)
            {
                cooldown = false;
            }
        }
    }
}
