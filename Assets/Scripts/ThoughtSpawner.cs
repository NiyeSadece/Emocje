using UnityEngine;
using System.Collections.Generic;

public class ThoughtSpawner : MonoBehaviour
{
    public GameObject positiveThoughtPrefab;
    public GameObject negativeThoughtPrefab;
    public float spawnRate = 1f;
    public float spawnRangeX = 8f;

    public List<string> positiveThoughts;
    public List<string> negativeThoughts;

    void Start()
    {
        InvokeRepeating("SpawnThought", 1f, spawnRate);
    }

    void SpawnThought()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);
        GameObject thought;

        if (Random.value > 0.5f)
        {
            thought = Instantiate(positiveThoughtPrefab, spawnPosition, Quaternion.identity);
            thought.GetComponent<ThoughtTextScript>().SetThoughtText(GetRandomPositiveThought());
        }
        else
        {
            thought = Instantiate(negativeThoughtPrefab, spawnPosition, Quaternion.identity);
            thought.GetComponent<ThoughtTextScript>().SetThoughtText(GetRandomNegativeThought());
        }
    }

    string GetRandomPositiveThought()
    {
        return positiveThoughts[Random.Range(0, positiveThoughts.Count)];
    }

    string GetRandomNegativeThought()
    {
        return negativeThoughts[Random.Range(0, negativeThoughts.Count)];
    }
}