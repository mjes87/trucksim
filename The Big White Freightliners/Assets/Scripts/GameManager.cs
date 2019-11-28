using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
=======
public enum GameState { INTRO, MENU, GAME }

public delegate void OnStateChangeHandler();

>>>>>>> d25e9062e481aa12fbf0ceab7df7bd3f734cfdfd
public class GameManager : MonoBehaviour
{
    protected GameManager() { }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
<<<<<<< HEAD
            DontDestroyOnLoad(gameObject);
            Instance = this;
=======
            if (GameManager.instance == null)
            {
                 GameManager.instance = new GameManager();
            }
            return GameManager.instance;
>>>>>>> d25e9062e481aa12fbf0ceab7df7bd3f734cfdfd
        }
    }

    public void OnApplicationQuit()
    {
        Instance = null;
    }
}
