using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCatalog : MonoBehaviour
{
    // private Dictionary<string, Skill> skillList = new Dictionary<string, Skill>();
    // private Dictionary<string, Ingredients> ingredList = new Dictionary<string, Ingredients>();
    [SerializeField] private CraftingSkill[] skills;
    public CraftingSkill[] Skills { get => skills; }

    private void Awake()
    {
        // CraftingSkill[] skills = GetComponentsInChildren<CraftingSkill>(true);
        // foreach (var skill in skills)
        // {
        //     skillList.TryAdd(skill.SkillName, skill);
        //     ingredList.TryAdd(skill.SkillName, skill.Ingredients);
        // }
    }

    public List<CraftingSkill> Choose(int c)
    {
        // List<CraftingSkill> skills = new List<CraftingSkill>(skillList.Values);
        List<int> order = Choose(skills.Length, c);
        List<CraftingSkill> choice = new List<CraftingSkill>();
        for (int i = 0; i < c; i++)
        {
            choice.Add(skills[order[i]]);
        }
        return choice;
    }

    private List<int> Choose(int n, int c)
    {
        // [0, 1, 2, 3, ... , n - 1]
        List<int> order = new List<int>();
        for (int i = 0; i < n; i++)
        {
            order.Add(i);
        }
        List<int> random = new List<int>();
        for (int i = n; i >= (n + 1) - c; i--)
        {
            int choose = Random.Range(0, i);
            random.Add(order[choose]);
            order.RemoveAt(choose);
        }
        return random;
    }

    public void ShowCatalog()
    {
        foreach (CraftingSkill skill in skills)
        {
            // Debug.Log(name + " : " + GetIngredients(name).ToString());
            Debug.Log(name + " : " + skill.Ingredients);
        }
    }
}
