using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCatalog : MonoBehaviour
{
    private Dictionary<string, Skill> skillList = new Dictionary<string, Skill>();
    private Dictionary<string, Ingredients> ingredList = new Dictionary<string, Ingredients>();

    private void Awake()
    {
        CraftingSkill[] skills = GetComponentsInChildren<CraftingSkill>(true);
        foreach (var skill in skills)
        {
            skillList.TryAdd(skill.SkillName, skill);
            ingredList.TryAdd(skill.SkillName, skill.Ingredients);
        }
    }

    public List<Skill> Choose(int c)
    {
        List<Skill> skills = new List<Skill>(skillList.Values);
        List<int> order = Choose(skills.Count, c);
        List<Skill> choice = new List<Skill>();
        for (int i = 0; i < c; i++)
        {
            choice.Add(skills[order[i]]);
        }
        return choice;
    }

    private List<int> Choose(int n, int c)
    {
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

    public Skill GetSkill(string name)
    {
        return skillList[name];
    }

    public Ingredients GetIngredients(string name)
    {
        return ingredList[name];
    }

    public void ShowCatalog()
    {
        foreach (string name in skillList.Keys)
        {
            Debug.Log(name + " : " + GetIngredients(name).ToString());
        }
    }
}
