using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static Vector2 RandomVector2(float minInclusiveXY, float maxInclusiveXY)
    {
        Vector2 vector = new Vector2();

        vector.x = UnityEngine.Random.Range(minInclusiveXY, maxInclusiveXY);
        vector.y = UnityEngine.Random.Range(minInclusiveXY, maxInclusiveXY);

        return vector;
    }

    public static Vector2 RandomVector2(Vector2 value)
    {
        Vector2 vector = new Vector2();

        vector.x = UnityEngine.Random.Range(value.x, value.y);
        vector.y = UnityEngine.Random.Range(value.x, value.y);

        return vector;
    }

    public static Vector2 RandomVector2Plus(float minInclusiveXY, float maxInclusiveXY, Vector2 vector)
    {
        Vector2 vector2Plus = new Vector2(vector.x,vector.y);

        vector2Plus.x += UnityEngine.Random.Range(minInclusiveXY, maxInclusiveXY);
        vector2Plus.y += UnityEngine.Random.Range(minInclusiveXY, maxInclusiveXY);

        return vector2Plus;


    }

    public static T GetRandomItem<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count-1)];
    }
}