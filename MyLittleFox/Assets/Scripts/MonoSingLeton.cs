using UnityEngine;

public class MonoSingLeton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    public T Intstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<T>();
            }
            return instance;
        }
    }
}