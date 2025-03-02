using UnityEngine;

public static class GameObjectExtensions
{
    public static T GetOrAdd<T>(this GameObject gameObject) where T : Component
    {
        T component = gameObject.GetComponent<T>();
        return component ?? gameObject.AddComponent<T>();
    }
}
