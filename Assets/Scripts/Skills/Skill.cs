using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public int skillNumber;
    public GameObject skillUI;

    public abstract void handleSkill(KeyCode k);


}
