using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] prefabs;
        [SerializeField] private int quantity = 1;
        [SerializeField] private float rate = 1;

        private void Start()
        {
            Spawn(quantity, rate);
        }

        private void Spawn(int quantity, float rate)
        {
            for (int i = 0; i < quantity; i++)
            {
                if (Random.Range(0.0f, 1.0f) < rate)
                {
                    GameObject instance = Instantiate(RandomGameObject(), transform.parent);
                    Vector2 localPosition = (Vector2) transform.localPosition + RandomVector2();
                    instance.transform.localPosition = localPosition;
                }
            }
        }

        private Vector2 RandomVector2()
        {
            float length = transform.lossyScale.x / 2;
            float height = transform.lossyScale.y / 2;
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

