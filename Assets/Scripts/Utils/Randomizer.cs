using UnityEngine;


public static class Randomizer
{

    //if(Random.value > 0.5) //%50 percent chance
    // {//code here
    // }

    // if(Random.value > 0.2) //%80 percent chance (1 - 0.2 is 0.8)
    // { //code here
    // }

    // if(Random.value > 0.7) //%30 percent chance (1 - 0.7 is 0.3)
    // { //code here
    // }

    public static bool GetRandomChance(float percentChance)
    {
        return Random.value > (100 - percentChance) / 100;
    }

    public static float GetRandom(float min, float max, float mult = 1f, bool isInt = false)
    {
        float rnd = (float)System.Math.Round(Random.Range(min, max));
        if (isInt) return rnd;
        return ((rnd * 100f) / 100f) * mult;
    }

    public static float GetRandomFull(float min, float max)
    {
        return Random.Range(min, max);
    }

    public static int GetRandomInt(int min, int max)
    {
        return Random.Range(min, max);
    }
}
