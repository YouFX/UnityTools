using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public static class MathTool
{

    #region————————————————————————————————————洗牌算法——————————————————————————————————————————————
    public static void Shuffle<T>(this List<T> list)
    {
        var n = list.Count;
        while (n-- > 1)
        {
            int k = Random.Range(0, n);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
    public static void Shuffle<T>(this List<T> list, RandomGenerator rng)
    {
        var n = list.Count;
        while (n > 0)
        {
            int k = rng.RandiRange(0, n);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
            n--;
        }
    }

    public static void Shuffle<T>(this T[] array)
    {
        var n = array.Length;
        while (n-- > 1)
        {
            int k = Random.Range(0, n);
            (array[k], array[n]) = (array[n], array[k]);
        }
    }
    public static void Shuffle<T>(this T[] array, RandomGenerator rng)
    {
        var n = array.Length;
        while (n-- > 1)
        {
            int k = rng.RandiRange(0, n);
            (array[k], array[n]) = (array[n], array[k]);
        }
    }
    #endregion
    public static T RollByWeight<T>(T[] values, int[] weights)
    {
        int sum = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            sum += weights[i];
        }
        int roll = Random.Range(1, sum + 1);

        int current = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            current += weights[i];
            if (roll < current)
            {
                return values[i];
            }
        }

        roll = Random.Range(0, weights.Length);
        if (values.Length <= roll)
        {
            return default;
        }
        return values[roll];
    }





    #region Rotate
    public static Vector2 Rotate(this Vector2 v2, Vector3 euler)
    {
        Quaternion q = Quaternion.Euler(euler);
        return q * v2;
    }
    public static Vector2 Rotate(this Vector2 v2, float x, float y, float z)
    {
        Quaternion q = Quaternion.Euler(x, y, z);
        return q * v2;
    }
    public static Vector3 Rotate(this Vector3 v3, Vector3 euler)
    {
        Quaternion q = Quaternion.Euler(euler);
        return q * v3;
    }
    public static Vector3 Rotate(this Vector3 v3, float x, float y, float z)
    {
        Quaternion q = Quaternion.Euler(x, y, z);
        return q * v3;
    }
    #endregion


    public static string ToSignString(this int value)
    {
        if (value > 0)
        {
            return $"+{value}";
        }
        else
        {
            return value.ToString();
        }
    }
    public static string ToSignString(this float value)
    {
        if (value > 0)
        {
            return $"+{value}";
        }
        else
        {
            return value.ToString();
        }
    }
    public static string ToSignString_Percentage(this float value)
    {
        float v = value * 100;
        if (v > 0)
        {
            return $"+{v}%";
        }
        else
        {
            return $"{v}%";
        }
    }


    public static Transform GetNearObj(this Transform self, List<Transform> list)
    {
        if (list == null || list.Count == 0) return null;
        if (list.Count == 1)
        {
            return list[0];
        }
        Transform near = list[0];
        float min = Vector3.Distance(self.position, list[0].position);

        for (int i = 1; i < list.Count; i++)
        {
            float dis = Vector3.Distance(self.position, list[i].position);
            if (dis < min)
            {
                min = dis;
                near = list[i];
            }
        }
        return near;
    }
    public static T GetNearObj<T>(this Transform self, List<T> list) where T : MonoBehaviour
    {
        if (list == null || list.Count == 0) return null;
        if (list.Count == 1)
        {
            return list[0];
        }
        T near = list[0];
        float min = Vector3.Distance(self.position, list[0].transform.position);

        for (int i = 1; i < list.Count; i++)
        {
            float dis = Vector3.Distance(self.position, list[i].transform.position);
            if (dis < min)
            {
                min = dis;
                near = list[i];
            }
        }
        return near;
    }

}
