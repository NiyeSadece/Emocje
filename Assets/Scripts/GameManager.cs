using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Dodaj, aby obs³ugiwaæ zmiany scen

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int NumberOfBerries;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Zachowaj GameManager miêdzy scenami

        }
        else if (instance != this)
        {
            Destroy(gameObject); // Usuñ duplikaty
        }
    }

    private void OnEnable()
    {
        // Subskrybuj wydarzenie zmiany sceny
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Usuñ subskrypcjê, aby unikn¹æ wycieków pamiêci
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name);

        // ZnajdŸ wszystkie BreathController w nowej scenie i zresetuj ich stan
        var breathControllers = Object.FindObjectsByType<BreathController>(FindObjectsSortMode.None); // U¿yj nowej metody
        foreach (BreathController controller in breathControllers)
        {
            controller.ResetState();
            Debug.Log("Reset BreathController in scene: " + scene.name);
        }
    }
}
