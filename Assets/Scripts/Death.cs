using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public void Manage()
    {
        gameObject.SetActive(false);
        Debug.Log(name + " has died");
        bool hasLooting = TryGetComponent<Looting>(out Looting looting);
        if (hasLooting)
        {
            looting.Drop();
        }
    }
}
