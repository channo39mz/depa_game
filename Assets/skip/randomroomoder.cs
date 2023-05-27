using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class randomroomoder : MonoBehaviour
{
    public static string[] Order;
    
    public static int num = 0;
    public static List<int> orderOfmap = new List<int> { 1, 2, 3, 4 ,5 ,6};
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = SceneUtility.GetScenePathByBuildIndex(i);
        }
        Order = scenes;
         foreach (string a in Order)
         {
             Debug.Log(a);
         }

        
        //SceneManager.LoadScene(Oder[oderOfmap[num]]);
        //num++;
    }

    void Shiff<T>(List<T> inputList)
    {
        
        for (int i = 0; i < inputList.Count - 1; i++)
        {

            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            if(i%5 == 0 || rand %5 == 0)
            {
                continue;
            }
            else
            {
                inputList[i] = inputList[rand];
                inputList[rand] = temp;
            }
   
        }
        


    }

    public void changemap()
    {
        Shiff(orderOfmap);
        foreach (var item in orderOfmap)
        {
            Debug.Log(item.ToString());
        }
        Debug.Log("map");
       // Debug.Log(oderOfmap.toString());
       
       
         SceneManager.LoadScene(Order[orderOfmap[num]]);
         DontDestroyOnLoad(Player);
         Player.transform.position = new Vector3(0, 0, 0);
         Player.SetActive(true);
         num++;
        
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            // Debug.Log(Order[oderOfmap[num]]);
            SceneManager.LoadScene(Order[orderOfmap[num]]);
            DontDestroyOnLoad(collision);
            collision.transform.position = new Vector3(0,0,0);
            num++;
        }
        
    }
}
