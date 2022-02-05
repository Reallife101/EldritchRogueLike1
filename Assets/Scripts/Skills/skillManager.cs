using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillManager : MonoBehaviour
{
    public Skill skillOne;
    public Skill skillTwo;
    public Skill skillThree;

    // Update is called once per frame
    void Update()
    {
        if (skillOne)
            skillOne.handleSkill(KeyCode.E);
        if (skillTwo)
            skillTwo.handleSkill(KeyCode.Q);
        if (skillThree)
            skillThree.handleSkill(KeyCode.R);

    }
}
