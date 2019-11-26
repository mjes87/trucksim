using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { INTRO, MENU, GAMEPLAY }
public enum CityTrafficLevels   { LIGHT, MODERATE, HEAVY }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{

    public float[] travelDelays = { 1.0f, 1.5f, 3.0f, 6.0f };


    protected GameManager() { }

    private static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;

    public GameState gameState { get; private set; }

    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

    public void OnApplicationQuit()
    {
        GameManager.instance = null;
    }
}
