using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private SkillCatalog catalog;
    private void Start() {
        catalog.showCatalog();
    }
}
