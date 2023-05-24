using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomOder : MonoBehaviour
{
    List<int> oder = new List<int> { 0 , 1 , 2 , 3 , 4 };
    public GameObject position;
    public GameObject[] room;
    void Start()
    {
        Shiff(oder);
        Debug.Log(string.Join(",",oder));
        setroom();
        Debug.Log("done");
    }

    void setroom()
    {
        for(int j = 0; j < oder.Count - 1; j++)
        {
            position.transform.position = room[j].transform.position;
            room[j].transform.position = room[oder[j]].transform.position;
            room[oder[j]].transform.position = position.transform.position;
        }
    }
    void Shiff<T>(List<T> inputList)
    {  
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
    void Update()
    {
        
    }
}
