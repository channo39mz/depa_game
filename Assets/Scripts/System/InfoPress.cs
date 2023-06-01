using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPress : MonoBehaviour
{
    public void info(){
        if(gameObject.activeSelf == true){
            gameObject.SetActive(false);
        }
        else{
            gameObject.SetActive(true);
        }
    }
}
