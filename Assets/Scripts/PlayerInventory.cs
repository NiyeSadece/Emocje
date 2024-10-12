using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public UnityEvent<PlayerInventory> OnBerryCollected;
    public void BerryCollected()
    {
        GameManager.instance.NumberOfBerries++;
        Debug.Log(GameManager.instance.NumberOfBerries);
        OnBerryCollected.Invoke(this);
    }
}
