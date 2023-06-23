using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("Main")]
    public string levelId = "begin";
    public bool isMoving = true;
    public float speed = 0.15f;
    public bool isUnderAcceleration = false;
    [Header("Spawn")]
    public GameObject startLevel;
    public GameObject endLevel;
    public GameObject[] cutItems;
    public GameObject[] clouds;
    public int minItemsPerLevel = 3;
    public int maxItemsPerLevel = 8;
    public int minCloudsPerLevel = 1;
    public int maxCloudsPerLevel = 3;

    private void Awake()
    {
        if (startLevel != null && endLevel != null)
        {
            SpawnItems(cutItems, minItemsPerLevel, maxItemsPerLevel, 0f);
            SpawnItems(clouds, minCloudsPerLevel, maxCloudsPerLevel, 0.398f);
        }
    }

    private void SpawnItems(GameObject[] items, int minItemPerLevel, int maxItemPerLevel, float yPos)
    {
        for (int i = 0; i < Randomizer.GetRandomInt(minItemPerLevel, maxItemPerLevel); i++)
        {
            float randomPosition = Randomizer.GetRandomFull(startLevel.transform.position.x, endLevel.transform.position.x);
            int randomNumber = Randomizer.GetRandomInt(0, items.Length);
            GameObject newItem = Instantiate(items[randomNumber], new Vector3(randomPosition, yPos, 0), Quaternion.identity);
            newItem.transform.parent = gameObject.transform;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving) MoveSelf();
    }

    public void MoveSelf()
    {
        float acceleration = 0f;
        if (isUnderAcceleration) acceleration = WorldAcceleration.GetAcceleration();
        transform.Translate((speed + (acceleration)) * Time.deltaTime * Vector2.left);
    }
}
