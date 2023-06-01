using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Sming : SkillManager
{
    private Animator animator;
    [SerializeField] private bool isTiger = false;
    public bool IsTiger
    {
        get => isTiger;
        private set
        {
            isTiger = value;
            if (value)
            {
                animator.SetBool("IsTiger", true);
            }
            else
            {
                animator.SetBool("IsTiger", false);
            }
        }
    }
    private GameObject Buff;
    private GameObject Dash;
    private GameObject Roar;
    private GameObject Slash;
    private GameObject Shooting;

    private void Start()
    {
        Buff = GetComponentInChildren<Buff>(true).gameObject;
        Dash = GetComponentInChildren<Dash>(true).gameObject;
        Roar = GetComponentInChildren<Roar>(true).gameObject;
        Slash = GetComponentInChildren<Slash>(true).gameObject;
        Shooting = GetComponentInChildren<Shooting>(true).gameObject;
        skills.Add(Buff);
        skills.Add(Dash);
        skills.Add(Roar);
        skills.Add(Slash);
        skills.Add(Shooting);
        animator = GetComponent<Animator>();
        IsTiger = isTiger;
        StartCoroutine(DoActionForSeconds(10));
    }

    public void RandomAction()
    {
        EnemyMovement movement = GetComponent<EnemyMovement>();
        Disable();
        int action = Random.Range(1, 7); // 1 - 6
        switch (action)
        {
            case 1:
                // tiger speed
                Debug.Log("1");
                if (IsTiger)
                {
                    Slash.SetActive(true);
                    Buff.SetActive(true);
                }
                else
                {
                    IsTiger = true;
                    Roar.SetActive(true);
                }
                break;
            case 2:
                // tiger warp
                Debug.Log("2");
                if (IsTiger)
                {
                    Dash.SetActive(true);
                }
                else
                {
                    IsTiger = true;
                    Roar.SetActive(true);
                }
                break;
            case 3:
                // tiger roar
                Debug.Log("3");
                if (IsTiger)
                {
                    Roar.SetActive(true);
                }
                else
                {
                    IsTiger = true;
                    Roar.SetActive(true);
                }
                break;
            case 4:
                // transform to human
                Debug.Log("4");
                IsTiger = false;
                Shooting.SetActive(true);
                break;
            case 5:
                // transform to tiger
                Debug.Log("5");
                IsTiger = true;
                Roar.SetActive(true);
                break;
            case 6:
                // charm
                Debug.Log("6");
                IsTiger = false;
                Shooting.SetActive(true);
                break;
        }
    }

    private IEnumerator DoActionForSeconds(float time)
    {
        while (true)
        {
            RandomAction();
            yield return new WaitForSeconds(time);
            Disable();
        }
    }
}
