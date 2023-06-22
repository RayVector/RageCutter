using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [Header("Main")]
    public float spawnLevelDelay = 0.0f;
    public float spawnLevelStep = 50f;
    public GameObject LevelObject;

    private void Start()
    {
        LevelSpawn();
    }

    public void LevelSpawn()
    {
        InvokeRepeating(nameof(SpawnLevel), spawnLevelDelay, spawnLevelStep);
    }

    public void SpawnLevel()
    {
        Vector3 position = new Vector3(transform.position.x, 0, 0);
        Instantiate(LevelObject, position, Quaternion.identity);
    }
}
