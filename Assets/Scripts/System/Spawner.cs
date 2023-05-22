using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] prefabs;

        private void Start()
        {
            GameObject instance = Instantiate(RandomGameObject(), transform.parent);
            Vector2 localPosition = (Vector2) transform.localPosition + RandomVector2();
            instance.transform.localPosition = localPosition;
        }

        private Vector2 RandomVector2()
        {
            float length = transform.localScale.x / 2;
            float height = transform.localScale.y / 2;
            float x = Random.Range(-length, length);
            float y = Random.Range(-height, height);
            return new Vector2(x, y);
        }

        private GameObject RandomGameObject()
        {
            int random = Random.Range(0, prefabs.Length);
            return prefabs[random];
        }
    }
}
    
