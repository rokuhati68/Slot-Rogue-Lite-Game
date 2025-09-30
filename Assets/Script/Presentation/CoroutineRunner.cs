// Assets/Scripts/Infrastructure/CoroutineRunner.cs
using System.Collections;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    public static CoroutineRunner Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Coroutine Run(IEnumerator routine) => StartCoroutine(routine);
    public void Stop(Coroutine c) { if (c != null) StopCoroutine(c); }
}
