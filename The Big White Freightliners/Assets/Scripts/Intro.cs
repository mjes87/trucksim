using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    GameManager GM;
    
    void Awake ()
    {
        GM = GameManager.Instance;
        GM.OnStateChange += HandleOnStateChange;

        Debug.Log("Current State OnAwake: " + GM.gameState);
    }
    
    void Start()
    {
        Debug.Log("Game start State: " + GM.gameState);
    }

    public void HandleOnStateChange()
    {
        GM.SetGameState(GameState.MENU);
        Debug.Log("Changing state to: " + GM.gameState);
        Invoke("LoadLevel", 3f);
    }

    public void LoadLevel()
    {
        Application.LoadLevel("Menu");
    }
}
