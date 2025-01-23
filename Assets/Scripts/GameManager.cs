using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Dodaj, aby obs�ugiwa� zmiany scen

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int NumberOfBerries;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Zachowaj GameManager mi�dzy scenami

        }
        else if (instance != this)
        {
            Destroy(gameObject); // Usu� duplikaty
        }
    }

    private void OnEnable()
    {
        // Subskrybuj wydarzenie zmiany sceny
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Usu� subskrypcj�, aby unikn�� wyciek�w pami�ci
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name);

        // Znajd� wszystkie BreathController w nowej scenie i zresetuj ich stan
        var breathControllers = Object.FindObjectsByType<BreathController>(FindObjectsSortMode.None); // U�yj nowej metody
        foreach (BreathController controller in breathControllers)
        {
            controller.ResetState();
            Debug.Log("Reset BreathController in scene: " + scene.name);
        }
    }
}
