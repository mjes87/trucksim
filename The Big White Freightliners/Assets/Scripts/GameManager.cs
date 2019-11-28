using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected GameManager() { }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    public void OnApplicationQuit()
    {
        Instance = null;
    }
}
