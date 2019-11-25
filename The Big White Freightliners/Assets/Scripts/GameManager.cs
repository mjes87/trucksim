using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class GameManager : MonoBehaviour
{
    enum CityTrafficLevels
    {
        LIGHT,
        MODERATE,
        HEAVY,
    }
    public float[] travelDelays = { 1.0f, 1.5f, 3.0f, 6.0f };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
=======
public enum GameState { INTRO, MENU, GAMEPLAY }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
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
>>>>>>> fc35dc4df7e41c676c616b26785e40fb368ae902
    }
}
