using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] private string skillName;
    public string SkillName { get => skillName; }
    [SerializeField] private string description;
    public string Description { get => description; }
    public Sprite image;
    public Sprite imageInfo;
}
