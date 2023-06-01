using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    protected List<GameObject> skills = new List<GameObject>();

    public void Disable()
    {
        foreach (GameObject skill in skills)
        {
            skill.SetActive(false);
        }
    }
}
