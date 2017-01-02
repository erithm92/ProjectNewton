using UnityEngine;


public class MySingleton<T> : MonoBehaviour where T : MySingleton<T>
{
    private static volatile T _instance = null;
    private static object _lock = new object();

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        GameObject go = new GameObject();
                        _instance = go.AddComponent<T>();
                        go.name = typeof(T).ToString() + " singleton";
                        DontDestroyOnLoad(go);
                    }
                }
            }
            return _instance;
        }
    }
}
