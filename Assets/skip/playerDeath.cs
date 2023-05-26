using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : Death
{
    public GameObject endcamera;
    public override void Manage()
    {
        endcamera.SetActive(true);
        base.Manage();
        gameObject.SetActive(false);
        Debug.Log(name + " has died");
        bool hasLooting = TryGetComponent<Looting>(out Looting looting);
        if (hasLooting)
        {
            looting.Drop();
        }
    }
}
