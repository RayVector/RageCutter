using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [Header("Main")]
    public float spawnLevelDelay = 0.0f;
    public float spawnLevelStep = 50f;
    public PlayerState playerState;
    public GameObject[] Levels;

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
        if (playerState.points < 50)
        {
            CreateLevel(Levels[0]);
        } else if (playerState.points > 50 && playerState.points < 100)
        {
            CreateLevel(Levels[1]);
        } else if (playerState.points > 150 && playerState.points < 200)
        {
            CreateLevel(Levels[2]);
        }
    }

    private void CreateLevel(GameObject level)
    {
        Vector3 position = new Vector3(transform.position.x, 0, 0);
        Instantiate(level, position, Quaternion.identity);
    }
}
