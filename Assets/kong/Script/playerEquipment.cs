using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEquipment : MonoBehaviour
{
    public Player hero;
    public Weapon curWeapon;
    public GameObject heroWeapon;
    private Vector3 worldPosition;
    [SerializeField] private Animator anime;
    [SerializeField] private float attackSpeed;
    void Start()
    {
        curWeapon.transform.eulerAngles = new Vector3(0,0,-90);
    }

    void Update()
    {
        getMousePosition();
        weaponRotate();

        attack();
    }

    private void getMousePosition(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void weaponRotate(){
        Vector3 aim = (worldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aim.y,aim.x) * Mathf.Rad2Deg;
        heroWeapon.transform.eulerAngles = new Vector3(0,0,angle);
    }

    private void attack(){
        if(Input.GetMouseButtonDown(0)){
            anime.SetTrigger("Attack");
        }
    }

    private void OnTriggerEnter2D(Collider2D a){
        if(a.tag == "Enemy"){
            Debug.Log("AHHHHHHHHH");
        }
    }
}
