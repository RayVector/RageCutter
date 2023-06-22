using UnityEngine;

public static class WorldAcceleration
{
    public static float movingMultiple = 150f;
    public static float GetAcceleration()
    {
        return Time.timeSinceLevelLoad / movingMultiple;
    }
}
