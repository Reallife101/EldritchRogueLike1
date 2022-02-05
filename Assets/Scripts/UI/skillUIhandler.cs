using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillUIhandler : MonoBehaviour
{
    private Skill skillOne;
    private Skill skillTwo;
    private Skill skillThree;

    // Start is called before the first frame update
    void Start()
    {
        grabSkills();
        orderUI(skillOne, skillTwo, skillThree);
    }

    void grabSkills()
    {
        skillManager sm = GetComponentInChildren<skillManager>();
        skillOne = sm.skillOne;
        skillTwo = sm.skillTwo;
        skillThree = sm.skillThree;
    }

    void orderUI(Skill one, Skill two, Skill three)
    {
        List<Skill> l = new List<Skill>();

        if (one)
        {
            l.Add(one);
        }
        if (two)
        {
            l.Add(two);
        }
        if (three)
        {
            l.Add(three);
        }

        for (int i = 0; i < l.Count; i++)
        {
            enableSkill(l[i], i);
        }
    }

    void enableSkill(Skill skill, int num)
    {
        if (skill != null)
        {
            Vector3 position = skill.skillUI.GetComponent<RectTransform>().anchoredPosition;
            skill.skillUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(position.x, 20+ 35*(num), position.z);
            skill.skillUI.SetActive(true);
        }

    }
}
