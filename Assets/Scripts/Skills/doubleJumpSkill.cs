using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJumpSkill : Skill
{
    public GameObject player;
    private movement mv;
    public int numExtraJumpsTotal = 1;
    private int numExtraJumpsLeft;
    public GameObject spec;


    // Start is called before the first frame update
    void Start()
    {
        mv = player.GetComponent<movement>();
        numExtraJumpsLeft = numExtraJumpsTotal;
    }

    public override void handleSkill(KeyCode k)
    {
        if (Input.GetButtonDown("Jump") && !mv.isGrounded && numExtraJumpsLeft>0)
        {
            mv.velocity.y = Mathf.Sqrt(mv.jumpHeight * -2f * mv.gravity);
            numExtraJumpsLeft -= 1;
            spec.SetActive(false);
        }
        else if (mv.isGrounded)
        {
            numExtraJumpsLeft = numExtraJumpsTotal;
            spec.SetActive(true);
        }
    }
}
