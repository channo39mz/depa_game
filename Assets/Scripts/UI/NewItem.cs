using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NewItem : ScriptableObject
{
    [SerializeField] private string description;
    public string Description { get; }
    public Sprite Icon;
}
