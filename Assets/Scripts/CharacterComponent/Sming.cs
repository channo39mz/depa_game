using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Sming : MonoBehaviour
{
    private Vector3 moveDirection;
    [SerializeField] private bool isTiger = true;
    public SmingSkills skills;

    private void Start()
    {
        skills.Buff = GetComponentInChildren<Buff>(true).gameObject;
        skills.Dash = GetComponentInChildren<Dash>(true).gameObject;
        skills.Roar = GetComponentInChildren<Roar>(true).gameObject;
        skills.Slash = GetComponentInChildren<Slash>(true).gameObject;
        skills.Shooting = GetComponentInChildren<Shooting>(true).gameObject;
        StartCoroutine(DoActionForSeconds(10));
    }

    public void RandomAction()
    {
        EnemyMovement movement = GetComponent<EnemyMovement>();
        skills.Disable();
        int action = Random.Range(1, 7); // 1 - 6
        switch (action)
        {
            case 1:
                // tiger speed
                Debug.Log("1");
                if (isTiger)
                {
                    skills.Slash.SetActive(true);
                    skills.Buff.SetActive(true);
                }
                else
                {
                    isTiger = true;
                    skills.Roar.SetActive(true);
                }
                break;
            case 2:
                // tiger warp
                Debug.Log("2");
                if (isTiger)
                {
                    skills.Slash.SetActive(true);
                    GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
                    gameObject.transform.position = new Vector2(player[0].transform.position.x - 1, player[0].transform.position.y - 1);
                }
                else
                {
                    isTiger = true;
                    skills.Roar.SetActive(true);
                }
                break;
            case 3:
                // tiger roar
                Debug.Log("3");
                if (isTiger)
                {
                    skills.Roar.SetActive(true);
                }
                else
                {
                    isTiger = true;
                    skills.Roar.SetActive(true);
                }
                break;
            case 4:
                // transform to human
                Debug.Log("4");
                isTiger = false;
                skills.Shooting.SetActive(true);
                break;
            case 5:
                // transform to tiger
                Debug.Log("5");
                isTiger = true;
                skills.Roar.SetActive(true);
                break;
            case 6:
                // charm
                Debug.Log("6");
                isTiger = false;
                skills.Shooting.SetActive(true);
                break;
        }
    }

    private IEnumerator DoActionForSeconds(float time)
    {
        while (true)
        {
            RandomAction();
            yield return new WaitForSeconds(time);
            skills.Disable();
        }
    }
}
