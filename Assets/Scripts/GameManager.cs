using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        }
        else if (instance != this)
        {
            Destroy(gameObject);
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

    [System.Obsolete]
    public void AddBerries(int amount)
    {
        NumberOfBerries += amount;
        FindObjectOfType<BerriesUI>().UpdateBerriesText();
    }

    public void DeleteBerries(int amount)
    {
        NumberOfBerries -= amount;
        NumberOfBerries = Mathf.Max(0, NumberOfBerries);
        FindObjectOfType<BerriesUI>().UpdateBerriesText();
    }

}
