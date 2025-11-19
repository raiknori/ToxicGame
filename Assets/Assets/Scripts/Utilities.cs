
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

    public static Vector3 GetVectorFromAngle(int angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static Vector3 GetVectorFromAngleInt(int angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    public static float GetAngleFromVectorFloatXZ(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    public static int GetAngleFromVector(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        int angle = Mathf.RoundToInt(n);

        return angle;
    }

    public static int GetAngleFromVector180(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        int angle = Mathf.RoundToInt(n);

        return angle;
    }

}