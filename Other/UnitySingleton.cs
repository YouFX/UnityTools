

using UnityEngine;

public class UnitySingleton<T> : MonoBehaviour where T : UnitySingleton<T>
{
    private static T ins;
    public static T Ins
    {
        get
        {
            if (ins == null)
            {
                ins = FindObjectOfType<T>();
                if (ins == null)
                {
                    GameObject obj = new GameObject();
                    ins = obj.AddComponent<T>();
                }
            }
            return ins;
        }
    }

    [SerializeField] private bool isDontDestroyOnLoad;
    protected virtual void Awake()
    {
        if (ins == null)
        {
            ins = (T)this;
            if (isDontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else if (ins != this)
        {
            Destroy(gameObject);
        }
    }
}