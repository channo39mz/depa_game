using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Theboss : MonoBehaviour
{
    public int xcount;
    private Vector3 moveDirection;
    public GameObject boomare;

    [SerializeField] private Rigidbody2D rb;
    async void Start()
    {
        while (true)
        {
            bossrandomAction();
            await Task.Delay(4000);
        }
   
    }
    async void AttackCoolDown(int times)
    {
        await Task.Delay(times);
    }
  

    public void bossrandomAction()
    {
        EnemyMovement speed = GetComponent<EnemyMovement>();
        // AttackRange rangeAtk = GetComponent<AttackRange>();
        
        moveDirection = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y).normalized;
        speed.Speed = 1;
        // rangeAtk.AtkRange = 1.5f;
        boomare.transform.localScale = new Vector3(0f, 0f, 0f);
        xcount = Random.Range(1, 7);// 1-6
        switch (xcount)
        {
            case 1:
                // tiger speed
                Debug.Log("1");
                AttackCoolDown(1500);
                speed.Speed = 3;
               
                break;
            case 2:
                // tiger warp
                GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
                Debug.Log("2");
                Debug.Log(player[0].transform.position);
                AttackCoolDown(1500);
                gameObject.transform.position = new Vector2 (player[0].transform.position.x - 1 , player[0].transform.position.y - 1);
                break;
            case 3:
                // tiger roar
                //rangeAtk.AtkRange = 5f;
                Vector3 sceal = new Vector3(5f, 5f, 5f);
                boomare.transform.localScale = sceal;
                speed.Speed = 0;
                Debug.Log("3");
                break;
            case 4:
                Debug.Log("4");
                Debug.Log("tran form to human");
                break;
            case 5:
                Debug.Log("tran form to tiger");
                Debug.Log("5");
                break;
            case 6:
                Debug.Log("charm");
                Debug.Log("6");
                break;
            default:
                Debug.Log("eror");
                break;

        }
        

        //a.Speed = 4;
    }
    void Update()
    {

    }
}
