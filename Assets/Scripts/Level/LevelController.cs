using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Randomizer;

public class LevelController : MonoBehaviour
{
    [Header("Main")]
    public string levelId = "begin";
    public bool isMoving = true;
    public float speed = 0.4f;
    [Header("Spawn")]
    public GameObject startLevel;
    public GameObject endLevel;
    public GameObject[] cutItems;
    public int minItemsPerLevel = 3;
    public int maxItemsPerLevel = 8;

    private void Awake()
    {
        if (startLevel != null && endLevel != null)
        {
            for (int i = 0; i < Randomizer.GetRandomInt(minItemsPerLevel, maxItemsPerLevel); i++)
            {
                float randomPosition = Randomizer.GetRandomFull(startLevel.transform.position.x, endLevel.transform.position.x);
                int randomNumber = Randomizer.GetRandomInt(0, cutItems.Length - 1);
                GameObject newCutItem = Instantiate(cutItems[randomNumber], new Vector3(randomPosition, 0, 0), Quaternion.identity);
                newCutItem.transform.parent = gameObject.transform;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isMoving) MoveSelf();
    }

    public void MoveSelf()
    {
        transform.Translate((speed) * Time.deltaTime * Vector2.left);
    }
}
