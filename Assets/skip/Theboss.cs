using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Theboss : MonoBehaviour
{
    public int xcount;
    private Vector3 moveDirection;
    public GameObject[] bossskill;
    public GameObject namalrangeAttack;
    public GameObject color;
    public bool isTiger = true;

    //[SerializeField] private Rigidbody2D rb;
  
    async void Start()
    {
     
        while (true)
        {
            await Task.Delay(2000);
            bossrandomAction();
            await Task.Delay(4000);
        }
   
    }
    async void AttackCoolDown(int times)
    {
        await Task.Delay(times);
    }
    public void colorOfboss()
    {
        if (isTiger)
        {
            color.SetActive(false);
        }
        else
        {
            color.SetActive(true);
        }
    }
    public void Reset()
    {
        foreach(GameObject g in bossskill)
        {
            g.SetActive(false);
        }
    }

    public void bossrandomAction()
    {
        EnemyMovement speed = GetComponent<EnemyMovement>();
        // AttackRange rangeAtk = GetComponent<AttackRange>();
        speed.Speed = 1;
        // rangeAtk.AtkRange = 1.5f;
        Reset();
        xcount = Random.Range(1, 7);// 1-6
        switch (xcount)
        {
            case 1:
                // tiger speed
                Debug.Log("1");
                //AttackCoolDown(1500);
                //speed.Speed = 3;
                if (isTiger)
                {
                    bossskill[2].SetActive(true);
                }
                else
                {
                    isTiger = true;
                    bossskill[0].SetActive(true);
                    speed.Speed = 0;
                }
                break;
            case 2:
                // tiger warp
                Debug.Log("2");
                if (isTiger)
                {
                    GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
                    Debug.Log(player[0].transform.position);
                    AttackCoolDown(1500);
                    gameObject.transform.position = new Vector2(player[0].transform.position.x - 1, player[0].transform.position.y - 1);
                }
                else
                {
                    isTiger = true;
                    bossskill[0].SetActive(true);
                    speed.Speed = 0;
                }
                break;
            case 3:
                // tiger roar
                if (isTiger)
                {
                    bossskill[0].SetActive(true);
                    speed.Speed = 0;
                }
                else
                {
                    isTiger = true;
                    bossskill[0].SetActive(true);
                    speed.Speed = 0;
                }
                Debug.Log("3");
                break;
            case 4:
                Debug.Log("4");
                Debug.Log("tran form to human");
                isTiger = false;
                bossskill[1].SetActive(true);
                break;
            case 5:
                Debug.Log("tran form to tiger");
                bossskill[0].SetActive(true);
                speed.Speed = 0;
                isTiger = true;
                Debug.Log("5");
                break;
            case 6:
                Debug.Log("charm");
                Debug.Log("6");
                isTiger = false;
                bossskill[1].SetActive(true);
                break;
            default:
                Debug.Log("eror");
                break;

        }
        colorOfboss();
        //a.Speed = 4;
    }
    void Update()
    {

    }
}
