using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Header("Main")]
    public int points = 0;
    public bool isPlayerCutting = false;
    public int distance = 0;

    public void GetPoints(int newPoints)
    {
        points += newPoints;
    }

    private void Awake()
    {
        InvokeRepeating("Walk", 0f, 1f);
    }

    private void Walk()
    {
        distance += 1;
    }
}
