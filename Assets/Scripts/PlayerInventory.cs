using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public void BerryCollected()
    {
        GameManager.instance.NumberOfBerries++;
        Debug.Log(GameManager.instance.NumberOfBerries);
    }
}
