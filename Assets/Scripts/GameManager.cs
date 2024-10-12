using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int NumberOfBerries;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager Instance Created: " + gameObject.name);

        }
        else if (instance != this)
        {
            Debug.Log("Duplicate GameManager Instance Destroyed: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
