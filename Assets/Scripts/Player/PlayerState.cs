using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Header("Main")]
    public int points = 0;

    public void GetPoints(int newPoints)
    {
        points += newPoints;
    }
}
